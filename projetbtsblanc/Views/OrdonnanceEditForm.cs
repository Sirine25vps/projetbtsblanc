using System;
using System.Collections.Generic;
using System.ComponentModel; // Indispensable pour BindingList
using System.Windows.Forms;
using projetbtsblanc.Controllers;
using projetbtsblanc.Models;

namespace projetbtsblanc.Views
{
    public partial class OrdonnanceEditForm : Form
    {
        // Contrôleurs pour récupérer les données
        private MedecinController _medController = new MedecinController();
        private MedicamentController _medocController = new MedicamentController();
        private OrdonnanceController _ordoController = new OrdonnanceController();

        // BindingList pour synchroniser automatiquement le DataGridView
        private BindingList<Medicament> _listeMedicaments = new BindingList<Medicament>();

        public OrdonnanceEditForm()
        {
            InitializeComponent();

            // Liaison de la liste au DataGridView
            dgvMedicaments.DataSource = _listeMedicaments;

            // Configuration de l'événement de chargement
            this.Load += OrdonnanceEditForm_Load;
        }

        private void OrdonnanceEditForm_Load(object sender, EventArgs e)
        {
            // Chargement des listes déroulantes
            cmbMedecins.DataSource = _medController.ObtenirTousLesMedecins();
            cmbMedecins.DisplayMember = "Nom"; 

            cmbMedicaments.DataSource = _medocController.ObtenirTousLesMedicaments();
            cmbMedicaments.DisplayMember = "Nom";
        }

        private void btnAjouterMedoc_Click(object sender, EventArgs e)
        {
            // Récupération de l'objet sélectionné
            Medicament m = (Medicament)cmbMedicaments.SelectedItem;

            if (m != null)
            {
                // Ajout à la BindingList, le DataGridView se met à jour tout seul
                _listeMedicaments.Add(m);
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifications de base
                if (cmbMedecins.SelectedItem == null) throw new Exception("Sélectionnez un médecin.");
                if (_listeMedicaments.Count == 0) throw new Exception("Ajoutez au moins un médicament.");

                // Création de l'objet Ordonnance
                Ordonnance nouvelleOrdo = new Ordonnance();
                nouvelleOrdo.DateEmission = DateTime.Now;
                nouvelleOrdo.Medecin = (Medecin)cmbMedecins.SelectedItem;

                // Conversion de la BindingList en List pour ton modèle
                nouvelleOrdo.Medicaments = new List<Medicament>(_listeMedicaments);

                // Appel au contrôleur pour enregistrer avec la transaction
                _ordoController.EnregistrerOrdonnance(nouvelleOrdo);

                MessageBox.Show("Ordonnance enregistrée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}