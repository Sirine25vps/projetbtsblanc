using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;


namespace projetbtsblanc.Views
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //Généré par le clic sur bouton S'inscrire
        private void btnInscription_Click(object sender, EventArgs e)
        {
            //On récupère toutes les saisies de l'utilisateur
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string rpps = txtRPPS.Text.Trim();
            string email = txtEmail.Text.Trim();
            string mdp = txtMdp.Text;
            string confirmation = txtConfirmation.Text;

            //Vérification qu'aucun champ n'est vide
            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom) || string.IsNullOrWhiteSpace(rpps) ||string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(mdp))
            {
                MessageBox.Show("Veuillez remplir tous les champs avant de valider", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Vérification que les mots de passe sont identiques
            if (mdp != confirmation)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmation.Clear();
                txtConfirmation.Focus();
                return;
            }

            //Succès 
            MessageBox.Show("compte créé avec succès !", "Félicitations", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //On ferme la fenêtre d'inscription pour revenir à la fenêtre de connexion
            this.Close();
        }
        private void linkConnexion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //on ferme la fenêtre d'inscription pour revenir à la fenêtre de connexion
            this.Close();
        } 

    }
}
