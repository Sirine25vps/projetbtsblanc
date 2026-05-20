using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projetbtsblanc.Views
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Récupération des données du formulaire
            string medoc = txtMedicament.Text.Trim();

            //Récupération des valeurs numériques et des textes des listes 
            decimal doseValeur = numDose.Value;
            string doseUnite = cmbDose.Text;
            decimal frequenceValeur = numFrequence.Value;
            string frequencePeriode = cmbFrequence.Text;

            //on convertit la date en format texte court 
            string dateLimite = dtpDateLimite.Value.ToShortDateString();

            // On vérifie que le médecin a bien rempli tous les champs obligatoires
            if (string.IsNullOrWhiteSpace(medoc) || string.IsNullOrWhiteSpace(doseUnite) || string.IsNullOrWhiteSpace(frequencePeriode))
            {
                MessageBox.Show("Veuillez saisir le nom du médicament, l'unité de la dose, ainsi que la période de la fréquence.", "Saisie incomplète", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //on assemble le chiffre et l'unité pour l'affichage dans le tableau 
            string doseComplete = doseValeur.ToString() + " " + doseUnite;

            //on assemble le chiffre et la période 
            string frequenceComplete = frequenceValeur.ToString() + " " + frequencePeriode;

            // l'ordre d'insertion doit correspondre exactement à l'ordre des colonnes créées dans le DataGridView
            dgvPrescriptions.Rows.Add("Patient Actuel", medoc, doseComplete, frequenceComplete, dateLimite);

            //Nettoyage des cases pour le médicament suivant 
            txtMedicament.Clear();
            numDose.Value = 0;
            cmbDose.SelectedIndex = -1; // déselectionne l'unité de dose
            numFrequence.Value = 1; // remet la fréquence à 1 par défaut
            cmbFrequence.SelectedIndex = -1; // déselectionne la période de fréquence
            txtMedicament.Focus(); // repositionne le curseur sur le nom du traitement pour une saisie rapide du médicament suivant
        }
        //clic sur le bouton supprimer
        private void btnSupprimerLigne_Click(object sender, EventArgs e)
        {
            //on vérifie qu'une ligne est bien sélectionnée dans le tableau
            if (dgvPrescriptions.SelectedRows.Count > 0)
            {
                //on supprime la ligne sélectionnée 
                dgvPrescriptions.Rows.RemoveAt(dgvPrescriptions.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer dans le tableau pour la supprimer.", "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //clic sur le bouton Valider du bas (pour enregistrer l'ordonnance 
        private void btnValiderFinal_Click(object sender, EventArgs e)
        {
            //on vérifie que le tableau contient au moins un médicament 
            if (dgvPrescriptions.Rows.Count > 0)
            {
                //simulation de l'enregistrement de l'ordonnance en base de données 
                MessageBox.Show("L'ordonnance a été validée et enregistrée avec succès dans le dossier du patient.", "Ordonnance enregistrée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // on ferme la fenêtre après validation

            }
            else
            {
                MessageBox.Show("Impossible de valider une ordonnance vide. Veuillez ajouter au moins un médicament", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
