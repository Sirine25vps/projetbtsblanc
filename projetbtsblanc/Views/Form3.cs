using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projetbtsblanc.Views
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        //Action  : clic sur le bouton créer
        private void btnCreer_Click(object sender, EventArgs e)
        {
            string nom = txtNomPatient.Text.Trim();
            string prenom = txtPrenomPatient.Text.Trim();
            string secu = mtbSecu.Text.Trim();

            //Verification minimum 
            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom))
            {
                MessageBox.Show("Le nom et le prénom sont obligatoires pour crééer un dossier patient", "Informations manquantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Simulation de l'insertion en base de données 
            MessageBox.Show($"Le dossier du patient {nom} {prenom} a été créé avec succès dans le système.", "Création validée", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // On vide les champs après la création 
            ViderChamps();
        }

        // Action : clic sur le bouton Modifier 
        private void btnModifier_Click(object sender, EventArgs e)
        {
            // Simulation d'une mise à jour
            MessageBox.Show("Les informations du patient ont été mises à jour.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Action : clic sur le bouton supprimer
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            //pour une suppression on demande toujours confirmation à l'utilisateur 
            DialogResult confirmation = MessageBox.Show("Êtes-vous sûr de vouloir supprimer définitivement ce dossier patient ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {

                //simulation du delete
                MessageBox.Show("Dossier patient supprimé.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViderChamps();
            }
        }
        //Action clic sur le "+ Nouv. Patient"
        private void btnNouveauPatient_Click(object sender, EventArgs e)
        {
            //création d'un exemplair de la fenetre de création de patient
            Form4 fenetreCreation = new Form4();

            //on l'ouvre en mode dialogue
            //cela va bloquer le Form3 en arrière plan tant que le Form4 est ouvert 
            fenetreCreation.ShowDialog();
        }

        //Methode : on créé une fonction séparée pour vider les champs ça évite de répéter le code 
        private void ViderChamps()
        {
            txtNomPatient.Clear();
            txtPrenomPatient.Clear();
            dtpDateNaissance.Value = DateTime.Now; //remet la date à aujourd'hui 
            numPoids.Value = 0;
            numTaille.Value = 0;
            cmbSexe.SelectedIndex = -1; //déselectionne le sexe 
            mtbSecu.Clear();
            txtPathologies.Clear();
            txtOrdonnances.Clear();
        }
        //Action : clic sur le bouton Rédiger Ordonnance
        private void btnRedigerOrdonnance_Click(object sender, EventArgs e)
        {
            //création d'un exemplaire de la fenetre de prescription
            Form5 fenetrePrescription = new Form5();

            // on l'ouvre en mode dialogue
            fenetrePrescription.ShowDialog();
        }
    }
}
