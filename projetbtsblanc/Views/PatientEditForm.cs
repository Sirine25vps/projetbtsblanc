using System;
using System.Windows.Forms;
using projetbtsblanc.Models;

namespace projetbtsblanc.Views
{
    public partial class PatientEditForm : Form
    {
        // Propriété publique pour récupérer le résultat depuis la liste 
        public Patient PatientSaisi { get; private set; }

        // Constructeur 1 : Création d'un nouveau patient
        public PatientEditForm()
        {
            InitializeComponent();
            this.Text = "Nouveau Patient";
        }

        // Constructeur 2 : Modification d'un patient existant
        public PatientEditForm(Patient patientAEditer)
        {
            InitializeComponent();
            this.Text = "Modifier Patient";

            // On pré-remplit les champs du formulaire avec les données du patient cliqué
            txtNom.Text = patientAEditer.Nom;
            txtPrenom.Text = patientAEditer.Prenom;
            dtpDateNaissance.Value = patientAEditer.DateNaissance;
            txtNumeroSecu.Text = patientAEditer.NumeroSecu;

            // Pré-remplissage des nouveaux champs
            numPoids.Value = (decimal)patientAEditer.Poids;
            numTaille.Value = (decimal)patientAEditer.Taille;
            cmbSexe.SelectedItem = patientAEditer.Sexe;
            txtPathologies.Text = patientAEditer.Pathologies;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            // 1. Validation assouplie (on vérifie juste que ce n'est pas vide)
            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtNumeroSecu.Text))
            {
                MessageBox.Show("Le nom et le numéro de sécurité sociale sont obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Création de l'objet
            PatientSaisi = new Patient(
                txtNom.Text.Trim(),
                txtPrenom.Text.Trim(),
                dtpDateNaissance.Value.Date,
                txtNumeroSecu.Text.Trim()
            );

            /// 3. Ajout des autres propriétés
            PatientSaisi.Poids = Convert.ToDouble(numPoids.Value);
            PatientSaisi.Taille = Convert.ToDouble(numTaille.Value);

            if (cmbSexe.SelectedItem != null)
                PatientSaisi.Sexe = cmbSexe.SelectedItem.ToString();
            else
                PatientSaisi.Sexe = "Non spécifié"; 


            PatientSaisi.Pathologies = txtPathologies.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}