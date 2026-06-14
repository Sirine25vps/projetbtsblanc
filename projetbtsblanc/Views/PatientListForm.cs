using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using projetbtsblanc.Controllers;
using projetbtsblanc.Models;

namespace projetbtsblanc.Views
{
    public partial class PatientListForm : Form
    {
        private readonly PatientController _controller;
        private readonly AllergieController _allergieController;

        public PatientListForm()
        {
            InitializeComponent();
            this.Load += PatientListForm_Load;

            _controller = new PatientController();
            _allergieController = new AllergieController();
        }

        private void PatientListForm_Load(object sender, EventArgs e)
        {
            List<string> allergies = _allergieController.ObtenirLibelles();
            // on ajoute une option par défaut si la liste n'est pas vide
            if (allergies != null)
            {
                allergies.Insert(0, "Toutes les allergies");
                cmbAllergies.DataSource = allergies;
            }
            RafraichirListe();
        }

        // ---------------------------------------------------
        // MÉTHODES DE FILTRAGE ET RAFRAICHISSEMENT 
        // ---------------------------------------------------

        private void btnReinitialiser_Click(object sender, EventArgs e)
        {
            txtRecherche.Text = "";
            if (cmbAllergies.Items.Count > 0)
            {
                cmbAllergies.SelectedIndex = 0;
            }
            RafraichirListe();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            AppliquerFiltres();
        }

        private void AppliquerFiltres()
        {
            string motCle = txtRecherche.Text.Trim();
            string allergie = (cmbAllergies.SelectedIndex > 0) ? cmbAllergies.SelectedItem.ToString() : null;

            try
            {
                List<Patient> patients = _controller.RechercherParNomEtAllergie(motCle, allergie);
                AfficherPatients(patients);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur SQL :\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RafraichirListe()
        {
            try
            {
                List<Patient> patients = _controller.ObtenirTousLesPatients();
                AfficherPatients(patients);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur base de données :\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------
        // ACTIONS DES BOUTONS 
        // ---------------------------------------------------

        private void btnNouveauPatient_Click(object sender, EventArgs e)
        {
            PatientEditForm form = new PatientEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // 1. On insère le patient et on récupère son nouvel ID
                int nouvelId = _controller.AjouterPatient(form.PatientSaisi);

                // 2. On insère ses allergies cochées en utilisant ce nouvel ID
                _controller.MettreAJourAllergies(nouvelId, form.AllergiesSelectionnees);

                RafraichirListe();
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null) return;

            Patient p = (Patient)dgvPatients.CurrentRow.DataBoundItem;
            OrdonnanceDetailForm form = new OrdonnanceDetailForm(p);
            form.ShowDialog();
        }

        private void btnSuppr_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null) return;

            Patient p = (Patient)dgvPatients.CurrentRow.DataBoundItem;

            if (MessageBox.Show("Supprimer ce patient ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _controller.SupprimerPatient(p.Id);
                    RafraichirListe();
                }
                catch (MySqlException ex) when (ex.Number == 1451)
                {
                    MessageBox.Show("Ce patient a des ordonnances, supprime-les d'abord.", "Erreur");
                }
            }
        }

        private void btnNouvOrdo_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null) return;

            Patient p = (Patient)dgvPatients.CurrentRow.DataBoundItem;
            OrdonnanceEditForm form = new OrdonnanceEditForm(p);
            form.ShowDialog();
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Patient p = (Patient)dgvPatients.Rows[e.RowIndex].DataBoundItem;
            PatientEditForm form = new PatientEditForm(p);

            if (form.ShowDialog() == DialogResult.OK)
            {
                // 1. On met à jour les informations textuelles du patient
                form.PatientSaisi.Id = p.Id;
                _controller.ModifierPatient(form.PatientSaisi);

                // 2. On met à jour les allergies cochées dans la base de données
                _controller.MettreAJourAllergies(p.Id, form.AllergiesSelectionnees);

                RafraichirListe();
            }
        }

        // ---------------------------------------------------
        // AFFICHAGE ET DATAGRIDVIEW 
        // ---------------------------------------------------

        private void AfficherPatients(List<Patient> patients)
        {
            dgvPatients.DataSource = null;

            // On force la régénération propre des colonnes
            dgvPatients.AutoGenerateColumns = true;
            dgvPatients.DataSource = patients;

            // On n'appelle la personnalisation qu'après que le DataSource soit bien lié
            PersonnaliserColonnes();
        }

        private void PersonnaliserColonnes()
        {
            if (dgvPatients.Columns.Count == 0) return;

            // 1. Masquer les colonnes techniques ou non désirées
            if (dgvPatients.Columns["Allergies"] != null) dgvPatients.Columns["Allergies"].Visible = false; // Cache le mot "(Collection)"

            // 2. On applique les textes des en-têtes
            if (dgvPatients.Columns["Id"] != null) dgvPatients.Columns["Id"].HeaderText = "N°";
            if (dgvPatients.Columns["Nom"] != null) dgvPatients.Columns["Nom"].HeaderText = "Nom";
            if (dgvPatients.Columns["Prenom"] != null) dgvPatients.Columns["Prenom"].HeaderText = "Prénom";

            if (dgvPatients.Columns["DateNaissance"] != null)
            {
                dgvPatients.Columns["DateNaissance"].HeaderText = "Date de naissance";
                dgvPatients.Columns["DateNaissance"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvPatients.Columns["NumeroSecu"] != null) dgvPatients.Columns["NumeroSecu"].HeaderText = "N° Sécurité sociale";
            if (dgvPatients.Columns["ListeAllergies"] != null) dgvPatients.Columns["ListeAllergies"].HeaderText = "Allergies"; // Propriété calculée
            if (dgvPatients.Columns["Pathologies"] != null) dgvPatients.Columns["Pathologies"].HeaderText = "Pathologies / Notes"; // Texte libre

            // 3. On désactive le tri automatique qui perturbe l'ordre
            foreach (DataGridViewColumn col in dgvPatients.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // 4. On applique l'ordre de gauche à droite
            try
            {
                int index = 0;
                if (dgvPatients.Columns["Nom"] != null) dgvPatients.Columns["Nom"].DisplayIndex = index++;
                if (dgvPatients.Columns["Prenom"] != null) dgvPatients.Columns["Prenom"].DisplayIndex = index++;
                if (dgvPatients.Columns["DateNaissance"] != null) dgvPatients.Columns["DateNaissance"].DisplayIndex = index++;
                if (dgvPatients.Columns["NumeroSecu"] != null) dgvPatients.Columns["NumeroSecu"].DisplayIndex = index++;
                if (dgvPatients.Columns["Sexe"] != null) dgvPatients.Columns["Sexe"].DisplayIndex = index++;
                if (dgvPatients.Columns["Pathologies"] != null) dgvPatients.Columns["Pathologies"].DisplayIndex = index++;
                if (dgvPatients.Columns["ListeAllergies"] != null) dgvPatients.Columns["ListeAllergies"].DisplayIndex = index++;
                if (dgvPatients.Columns["Id"] != null) dgvPatients.Columns["Id"].DisplayIndex = index++;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Erreur ordonnancement colonnes : " + ex.Message);
            }

            // 5. Paramètres visuels stricts pour empêcher la modification directe dans la grille
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.ReadOnly = true;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnGestionOrdonnances_Click(object sender, EventArgs e)
        {
            // On vérifie qu'un patient est bien sélectionné dans le tableau
            if (dgvPatients.CurrentRow != null && dgvPatients.CurrentRow.DataBoundItem is Patient patientSelectionne)
            {
                // On instancie le formulaire en lui passant le patient ciblé (Cas B)
                OrdonnanceListForm form = new OrdonnanceListForm(patientSelectionne);
                form.ShowDialog();
            }
            else
            {
                // Petit message de sécurité si on clique dans le vide
                MessageBox.Show("Veuillez d'abord sélectionner un patient dans la liste.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}