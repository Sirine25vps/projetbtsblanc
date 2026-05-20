using MySql.Data.MySqlClient;
using projetbtsblanc.Controllers;
using projetbtsblanc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projetbtsblanc.Views
{
    public partial class PatientDetailForm : Form
    {
        private readonly int _idPatient;
        private readonly PatientController _controller;
        // Le constructeur prend l'ID du patient à afficher.
        // C'est la méthode classique pour passer un paramètre
        // à un formulaire WinForms.
        public PatientDetailForm(int idPatient)
        {
            InitializeComponent();
            _idPatient = idPatient;
            _controller = new PatientController();

            this.Load += PatientDetailForm_Load;
        }
        private void PatientDetailForm_Load(object sender, EventArgs e)
        {
            try
            {
                ChargerPatient();
                ChargerHistorique();
            }
            catch (MySqlException ex)

            {
                MessageBox.Show(
                "Erreur base de données :\n" + ex.Message,
                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChargerPatient()
        {
            Patient p = _controller.ObtenirParId(_idPatient);
            if (p == null)
            {
                MessageBox.Show("Patient introuvable.", "Erreur");
                this.Close();
                return;
            }
            this.Text = "Fiche : " + p.Prenom + " " + p.Nom;
            lblNom.Text = p.Nom;
            lblPrenom.Text = p.Prenom;
            lblDateNaissance.Text = p.DateNaissance.ToString("dd/MM/yyyy");
            lblAge.Text = p.CalculerAge() + " ans";
            lblNumeroSecu.Text = p.NumeroSecu;
            lstAllergies.DataSource = p.Allergies;
        } //accolade de fin de la méthode ChargerPatient
        private void ChargerHistorique()
        {
            var historique = _controller.ObtenirHistorique(_idPatient);
            dgvHistorique.DataSource = historique;
            PersonnaliserColonnesHistorique();
        }
        private void PersonnaliserColonnesHistorique()
        {
            if (dgvHistorique.Columns.Count == 0) return;
            dgvHistorique.Columns["Id"].Visible = false;
            dgvHistorique.Columns["DateEmission"].HeaderText = "Date";
            dgvHistorique.Columns["DateEmission"]
            .DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHistorique.Columns["MedecinNom"].HeaderText = "Médecin";
            dgvHistorique.Columns["MedecinSpecialite"].HeaderText = "Spécialité";
            dgvHistorique.ReadOnly = true;
            dgvHistorique.AllowUserToAddRows = false;
            dgvHistorique.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
        }
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    } //accolade de fin de la classe PatientDetailForm
} 