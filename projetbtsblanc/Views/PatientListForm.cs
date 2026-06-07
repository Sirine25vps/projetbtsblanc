using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using projetbtsblanc.Controllers;
using projetbtsblanc.Models;
using projetbtsblanc.Views;

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
            RafraichirListe();
            List<string> allergies = _allergieController.ObtenirLibelles();
            cmbAllergies.DataSource = allergies;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRecherche.Text = "";
            RafraichirListe();
        }

        private void btnRechercher_Click_1(object sender, EventArgs e)
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
                string motCle = txtRecherche.Text.Trim();
                List<Patient> patients = string.IsNullOrEmpty(motCle)
                    ? _controller.ObtenirTousLesPatients()
                    : _controller.RechercherParNom(motCle);

                AfficherPatients(patients);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur base de données :\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CRUD : CREATE 
        private void btnNouveau_Click(object sender, EventArgs e)
        {
            PatientEditForm form = new PatientEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _controller.AjouterPatient(form.PatientSaisi);
                RafraichirListe();
            }
        }

        // CRUD : UPDATE 
        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Patient p = (Patient)dgvPatients.Rows[e.RowIndex].DataBoundItem;
            PatientEditForm form = new PatientEditForm(p);

            if (form.ShowDialog() == DialogResult.OK)
            {
                form.PatientSaisi.Id = p.Id;
                _controller.ModifierPatient(form.PatientSaisi);
                RafraichirListe();
            }
        }

        //  CRUD : DELETE 
        private void btnSupprimer_Click(object sender, EventArgs e)
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

        private void AfficherPatients(List<Patient> patients)
        {
            dgvPatients.DataSource = null;
            dgvPatients.DataSource = patients;
            PersonnaliserColonnes();
        }

        private void PersonnaliserColonnes()
        {
            if (dgvPatients.Columns.Count == 0) return;
            dgvPatients.Columns["Id"].HeaderText = "N°";
            dgvPatients.Columns["Nom"].HeaderText = "Nom";
            dgvPatients.Columns["Prenom"].HeaderText = "Prénom";
            dgvPatients.Columns["DateNaissance"].HeaderText = "Date de naissance";
            dgvPatients.Columns["NumeroSecu"].HeaderText = "N° Sécurité sociale";

            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPatients.ReadOnly = true;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}