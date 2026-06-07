using System;
using System.Windows.Forms;

namespace projetbtsblanc.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            // récupération des données
            string utilisateur = txtEmail.Text.Trim();
            string motDePasse = txtMdp.Text;

            // vérification de sécurité 
            if (string.IsNullOrWhiteSpace(utilisateur) || string.IsNullOrWhiteSpace(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs avant de valider", "Champs vides", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validation 
            if (utilisateur == "admin" && motDePasse == "admin")
            {
                // Succès : on affiche un message de bienvenue 
                MessageBox.Show($"Bienvenue, {utilisateur} !", "Connexion réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // On cache la fenêtre de connexion actuelle 
                this.Hide();

                // On instancie et on affiche le tableau de bord 
                PatientListForm accueil = new PatientListForm();

                // ShowDialog bloque le code ici tant que le tableau de bord est ouvert
                accueil.ShowDialog();

                // 3. Quand l'utilisateur ferme le tableau de bord, on ferme complètement l'application.
                this.Close();
            }
            else
            {
                // Échec : on affiche un message d'erreur 
                MessageBox.Show("Identifiant ou mot de passe incorrect.", "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Vide le mot de passe pour que l'utilisateur puisse le retaper 
                txtMdp.Clear();

                // Remet le curseur automatiquement dans la case 
                txtMdp.Focus();
            }
        }
    }
}