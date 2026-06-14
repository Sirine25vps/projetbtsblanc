using System;
using System.Collections.Generic;
using System.Windows.Forms;
using projetbtsblanc.Controllers;
using projetbtsblanc.Models;

namespace projetbtsblanc.Views
{
    public partial class OrdonnanceListForm : Form
    {
        private OrdonnanceController _controller = new OrdonnanceController();

        // Variable pour stocker le patient dont on consulte les ordonnances
        private Patient _patientConcerne;

        // 1. Constructeur par défaut (utilisé par le Designer)
        public OrdonnanceListForm()
        {
            InitializeComponent();

            // Abonnement aux événements
            this.Load += OrdonnanceListForm_Load;
            dgvOrdonnances.SelectionChanged += dgvOrdonnances_SelectionChanged;
        }

        // 2. Second constructeur pour recevoir le patient sélectionné
        public OrdonnanceListForm(Patient patient) : this()
        {
            _patientConcerne = patient;
        }

        private void OrdonnanceListForm_Load(object sender, EventArgs e)
        {
            // Configuration de base des tableaux
            dgvOrdonnances.ReadOnly = true;
            dgvLignes.ReadOnly = true;
            dgvOrdonnances.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLignes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdonnances.AllowUserToAddRows = false;
            dgvLignes.AllowUserToAddRows = false;

            // Mode de remplissage épuré (Fill)
            dgvOrdonnances.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLignes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Chargement des données selon le contexte
            if (_patientConcerne != null)
            {
                // On adapte le titre de la fenêtre dynamiquement
                this.Text = $"Ordonnances du patient : {_patientConcerne.Prenom} {_patientConcerne.Nom}";

                // On ne charge QUE les ordonnances de ce patient
                dgvOrdonnances.DataSource = _controller.ObtenirOrdonnancesParPatient(_patientConcerne.Id);
            }
            else
            {
                this.Text = "Liste globale des ordonnances";
                dgvOrdonnances.DataSource = _controller.ObtenirToutesLesOrdonnances();
            }

            PersonnaliserColonnes();
        }

        private void dgvOrdonnances_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrdonnances.CurrentRow != null && dgvOrdonnances.CurrentRow.DataBoundItem is Ordonnance selectedOrdo)
            {
                // Chargement des lignes de prescription (médicaments)
                dgvLignes.DataSource = _controller.ObtenirLignes(selectedOrdo.Id);
                PersonnaliserColonnesLignes();
            }
        }

        private void PersonnaliserColonnes()
        {
            if (dgvOrdonnances.Columns.Count == 0) return;

            if (dgvOrdonnances.Columns["Id"] != null) dgvOrdonnances.Columns["Id"].HeaderText = "N° Ordonnance";
            if (dgvOrdonnances.Columns["DateEmission"] != null) dgvOrdonnances.Columns["DateEmission"].HeaderText = "Date d'émission";
            if (dgvOrdonnances.Columns["Medecin"] != null) dgvOrdonnances.Columns["Medecin"].HeaderText = "Médecin";

            // CAS B : Si on est sur la fiche d'un patient précis, on masque sa propre colonne
            if (dgvOrdonnances.Columns["Patient"] != null)
            {
                if (_patientConcerne != null)
                    dgvOrdonnances.Columns["Patient"].Visible = false; // Invisible car redondant
                else
                    dgvOrdonnances.Columns["Patient"].HeaderText = "Patient";
            }
        }

        private void PersonnaliserColonnesLignes()
        {
            if (dgvLignes.Columns.Count == 0) return;

            if (dgvLignes.Columns["NomMedicament"] != null) dgvLignes.Columns["NomMedicament"].HeaderText = "Médicament";
            if (dgvLignes.Columns["Posologie"] != null) dgvLignes.Columns["Posologie"].HeaderText = "Posologie / Dose";
            if (dgvLignes.Columns["DureeJours"] != null) dgvLignes.Columns["DureeJours"].HeaderText = "Durée (jours)";
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}