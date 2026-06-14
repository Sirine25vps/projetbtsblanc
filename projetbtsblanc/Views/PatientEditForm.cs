using System;
using System.Collections.Generic;
using System.Windows.Forms;
using projetbtsblanc.Models;
using projetbtsblanc.Controllers;

namespace projetbtsblanc.Views
{
    public partial class PatientEditForm : Form
    {
        public Patient PatientSaisi { get; private set; }

        // Liste pour stocker les allergies cochées
        public List<string> AllergiesSelectionnees { get; private set; }

        private readonly AllergieController _allergieController;

        // Constructeur 1 : Création
        public PatientEditForm()
        {
            InitializeComponent();
            _allergieController = new AllergieController();
            this.Text = "Nouveau Patient";
            ChargerListeAllergies(null);
        }

        // Constructeur 2 : Modification
        public PatientEditForm(Patient patientAEditer)
        {
            InitializeComponent();
            _allergieController = new AllergieController();
            this.Text = "Modifier Patient";

            txtNom.Text = patientAEditer.Nom;
            txtPrenom.Text = patientAEditer.Prenom;
            dtpDateNaissance.Value = patientAEditer.DateNaissance;
            txtNumeroSecu.Text = patientAEditer.NumeroSecu;
            cmbSexe.SelectedItem = patientAEditer.Sexe;

           
            txtPathologies.Text = patientAEditer.Pathologies;

        // On charge les allergies et on coche celles que le patient a déjà
        ChargerListeAllergies(patientAEditer.Allergies);
        }

        private void ChargerListeAllergies(List<string> allergiesDuPatient)
        {
            List<string> toutesLesAllergies = _allergieController.ObtenirLibelles();
            if (toutesLesAllergies == null) return;

            foreach (string allergie in toutesLesAllergies)
            {
                // Si l'allergie est dans la liste du patient, on la coche (true), sinon false
                bool estCochee = allergiesDuPatient != null && allergiesDuPatient.Contains(allergie);
                clbAllergies.Items.Add(allergie, estCochee);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtNumeroSecu.Text))
            {
                MessageBox.Show("Le nom et le n° de sécu sont obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PatientSaisi = new Patient(
                txtNom.Text.Trim(),
                txtPrenom.Text.Trim(),
                dtpDateNaissance.Value.Date,
                txtNumeroSecu.Text.Trim()
            );

            PatientSaisi.Sexe = cmbSexe.SelectedItem != null ? cmbSexe.SelectedItem.ToString() : "Non spécifié";

            
            PatientSaisi.Pathologies = txtPathologies.Text.Trim();

            // On récupère toutes les cases cochées
            AllergiesSelectionnees = new List<string>();
            foreach (var item in clbAllergies.CheckedItems)
            {
                AllergiesSelectionnees.Add(item.ToString());
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}