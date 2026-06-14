using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using projetbtsblanc.Controllers;
using projetbtsblanc.Models;

namespace projetbtsblanc.Views
{
    public partial class OrdonnanceDetailForm : Form
    {
        private readonly Patient _patientConcerne;
        private readonly PatientController _controller;

        public OrdonnanceDetailForm(Patient patient)
        {
            InitializeComponent();
            _patientConcerne = patient;
            _controller = new PatientController();
            this.Load += PatientDetailForm_Load;
        }

        private void PatientDetailForm_Load(object sender, EventArgs e)
        {
            try
            {
                AfficherInfosPatient();
                ChargerHistorique();
            }
            catch (Exception ex) // Catch global pour éviter les crashs à l'affichage
            {
                MessageBox.Show("Erreur au chargement : " + ex.Message);
            }
        }

        private void AfficherInfosPatient()
        {
            this.Text = "Fiche : " + _patientConcerne.Prenom + " " + _patientConcerne.Nom;
            lblNom.Text = _patientConcerne.Nom;
            lblPrenom.Text = _patientConcerne.Prenom;
            lblDateNaissance.Text = _patientConcerne.DateNaissance.ToString("dd/MM/yyyy");
            lblAge.Text = _patientConcerne.CalculerAge() + " ans";
            lblNumeroSecu.Text = _patientConcerne.NumeroSecu;
            lstAllergies.DataSource = _patientConcerne.Allergies;
        }
        private void ChargerHistorique()
        {
            // 1. On récupère les données via le contrôleur
            var historique = _controller.ObtenirHistorique(_patientConcerne.Id);

            // 2. On crée une liste "plate" exprès pour l'affichage (ViewModel)
            var historiqueAffiche = new List<dynamic>();
            foreach (var ordo in historique)
            {
                historiqueAffiche.Add(new
                {
                    Date = ordo.DateEmission.ToString("dd/MM/yyyy"),
                    Médecin = ordo.Medecin != null ? ordo.Medecin.Nom : "Non renseigné"
                });
            }

            // 3. Remise à zéro totale du tableau pour effacer les fantômes du Designer
            dgvHistorique.DataSource = null;
            dgvHistorique.Columns.Clear();

            // 4. On demande au tableau de se générer UNIQUEMENT à partir de notre liste plate
            dgvHistorique.AutoGenerateColumns = true;
            dgvHistorique.DataSource = historiqueAffiche;

            // 5. Paramètres visuels stricts
            dgvHistorique.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorique.ReadOnly = true;
            dgvHistorique.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorique.AllowUserToAddRows = false;
        }
        private void btnFermer_Click(object sender, EventArgs e) => this.Close();
    }
}