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

        public PatientListForm()
        {
            InitializeComponent();
            this.Load += PatientListForm_Load;
            _controller = new PatientController();
        }

        // --- PARTIE 1 : LES ÉVÉNEMENTS (CLICS ET CHARGEMENT) ---

        private void PatientListForm_Load(object sender, EventArgs e)
        {
            RafraichirListe();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            RafraichirListe();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRecherche.Clear();
            RafraichirListe();
        }

        // --- PARTIE 2 : LA LOGIQUE (REFACTORING) ---

        private void RafraichirListe()
        {
            try
            {
                // On récupère le texte tapé dans la zone txtRecherche
                string motCle = txtRecherche.Text.Trim(); //vérifie qu'il récupère bien le texte et supprime les espaces superflus

                // Si la recherche est vide, on prend tout. Sinon, on utilise le filtre.
                List<Patient> patients = string.IsNullOrEmpty(motCle)
                    ? _controller.ObtenirTousLesPatients()
                    : _controller.RechercherParNom(motCle); //vérifie qu'il appelle la méthode avec MotClé

                AfficherPatients(patients);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur base de données :\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherPatients(List<Patient> patients)
        {
            dgvPatients.DataSource = null; //on vide la datasource avant de réassigner pour forcer le rafraîchissement

            dgvPatients.DataSource = patients; //vérifie qu'il assigne la liste de patients à la DataGridView

            dgvPatients.Refresh(); //demande à la DataGridView de se redessiner avec les nouvelles données

            PersonnaliserColonnes();
        }

        private void PersonnaliserColonnes()
        {
            if (dgvPatients.Columns.Count == 0) return;

            dgvPatients.Columns["Id"].HeaderText = "N°";
            dgvPatients.Columns["Id"].Width = 50;
            dgvPatients.Columns["Nom"].HeaderText = "Nom";
            dgvPatients.Columns["Prenom"].HeaderText = "Prénom";
            dgvPatients.Columns["DateNaissance"].HeaderText = "Date de naissance";
            dgvPatients.Columns["DateNaissance"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPatients.Columns["NumeroSecu"].HeaderText = "N° Sécurité sociale";

            if (dgvPatients.Columns.Contains("Allergies"))
                dgvPatients.Columns["Allergies"].Visible = false;

            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPatients.ReadOnly = true;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)

        {
           
            // Ignorer les clics sur l'en-tête de colonne
            if (e.RowIndex < 0) return;
            // Récupérer l'objet Patient lié à la ligne cliquée.
            // DataBoundItem contient l'objet de la liste DataSource
            // qui correspond à cette ligne.
            Patient p = (Patient)dgvPatients.Rows[e.RowIndex].DataBoundItem;
            // Ouvrir le formulaire de détail en mode "modal" :
            // ShowDialog() bloque la fenêtre parente jusqu'à fermeture.
            PatientDetailForm fiche = new PatientDetailForm(p.Id);
            fiche.ShowDialog(this);
            // (optionnel) Si le détail modifie le patient, on rafraîchit :
            // RafraichirListe();
        }
    }
}