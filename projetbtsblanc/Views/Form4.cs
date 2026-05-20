using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projetbtsblanc.Views
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        //action quand on clique sur "créer"
        private void btnCreer_Click(object sender, EventArgs e)
        {
            //récupération des données saisies
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();

            //vérification que les champs sont remplis 
            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom))
            {
                MessageBox.Show("Le nom et le prénom sont obligatoires pour créer un dossier patient.", "Informations manquantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //on arrête l'exécution ici si les champs ne sont pas correctement remplis
            }

            //validation et fermeture de la fenêtre
            MessageBox.Show($"Le dossier du patient {nom} {prenom} a bien été enregistré.", "Création réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //on ferme la fenêtre de création après la validation pour revenir au tableau de bord 
            this.Close();
        }
    }
}
