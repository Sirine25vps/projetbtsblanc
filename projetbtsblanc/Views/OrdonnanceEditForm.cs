using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        // Variable privée pour stocker le patient sélectionné
        private Patient _patientConcerne;

        // 1. Constructeur par défaut
        public OrdonnanceEditForm()
        {
            InitializeComponent();

            // Liaison de la liste au DataGridView
            dgvMedicaments.DataSource = _listeMedicaments;

            // Remplir l'espace gris vide avec les colonnes
            dgvMedicaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configuration de l'événement de chargement
            this.Load += OrdonnanceEditForm_Load;
        }

        // 2. Nouveau constructeur corrigé qui accepte le patient envoyé depuis PatientListForm 
        public OrdonnanceEditForm(Patient patient) : this()
        {
            this._patientConcerne = patient;
        }

        private void OrdonnanceEditForm_Load(object sender, EventArgs e)
        {
            // Chargement des listes déroulantes
            cmbMedecins.DataSource = _medController.ObtenirTousLesMedecins();
            cmbMedecins.DisplayMember = "Nom";

            cmbMedicaments.DataSource = _medocController.ObtenirTousLesMedicaments();
            cmbMedicaments.DisplayMember = "Nom";
        }

        private void btnAjouterMedoc_Click_1(object sender, EventArgs e)
        {
            // LECTURE SÉCURISÉE : Utilisation de 'as'. Si ça échoue, ça ne crashe pas, ça donne juste 'null'.
            Medicament m = cmbMedicaments.SelectedItem as Medicament;

            if (m != null)
            {
                // On crée une NOUVELLE instance pour la ligne de l'ordonnance
                Medicament medocAjoute = new Medicament(
                    m.CodeMedicament,
                    m.Nom,
                    numDose.Value.ToString(), // On récupère la valeur tapée dans le NumericUpDown
                    cmbUnite.Text             // On récupère le texte tapé/choisi dans le ComboBox
                );

                // Ajout à la BindingList, le DataGridView se met à jour tout seul
                _listeMedicaments.Add(medocAjoute);

                // Remise à zéro des champs pour préparer la saisie du médicament suivant
                numDose.Value = 0;
                cmbUnite.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un médicament valide dans la liste.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEnregistrer_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Vérifications de base
                if (cmbMedecins.SelectedItem == null) throw new Exception("Sélectionnez un médecin.");
                if (_listeMedicaments.Count == 0) throw new Exception("Ajoutez au moins un médicament dans le tableau.");
                if (_patientConcerne == null) throw new Exception("Aucun patient n'est associé à cette ordonnance.");

                // Création de l'objet Ordonnance
                Ordonnance nouvelleOrdo = new Ordonnance();
                nouvelleOrdo.DateEmission = DateTime.Now;
                nouvelleOrdo.Medecin = (Medecin)cmbMedecins.SelectedItem;

                // Association du patient sélectionné à l'ordonnance
                nouvelleOrdo.Patient = _patientConcerne;

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