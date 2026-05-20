// using: ce sont des boites à outils qu'on ouvre 
//system: contient les outils de base (comme les textes ou les dates)
//system.windows.forms: contient les outils pour faire des fenêtres (boutons, labels, etc)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//namespace: nom du "tiroir" de rangement

namespace projetbtsblanc.Views 
{

    //public partial class: public signifie que d'autres parties du programme peuvent voir cette fenêtre. partial signifie que le code est coupé en deux 

    //form c'est l'héritage, la classe Form1 hérite de la classe Form. 
    public partial class Form1 : Form
    {
        public Form1() 
            //form1() constructeur de la fenêtre
        {
            InitializeComponent(); //c'est une méthode vitale qui se trouve dans le fichier .Designer.cs, elle sert à initialiser tous les éléments de la fenêtre (boutons, labels, etc), sans elle la fenêtre serait vide. 

        }

        //private: seule cette fenetre peut utiliser cette fonction 
        //void: la fonction fait une action mais ne renvoie pas de résultat 
        //object sender, eventargs e: ce sont les paramètres de la fonction, ils sont nécessaires pour que la fonction puisse être utilisée comme un événement (par exemple, un clic sur un bouton). sender représente l'objet qui a déclenché l'événement (dans ce cas, le bouton de connexion), et e contient des informations supplémentaires sur l'événement (comme les coordonnées du clic, etc).
        private void btnConnexion_Click(object sender, EventArgs e)

        {
            //RECUPERATION DES DONNEES
            //.Trim() retire les espaces accidentels au début et à la fin
            //string déclare une variable de type texte
            //.Text récupère ce qui est écrit dans la case
            string utilisateur = txtEmail.Text.Trim();
            string motDePasse = txtMdp.Text;

            //VERIFICATION DE SECURITE 
            // on vérifie si une des cases est vide ou ne contient que des espaces 
            if (string.IsNullOrWhiteSpace(utilisateur) || string.IsNullOrWhiteSpace(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs avant de valider", "Champs vides", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //on arrête la fonction ici, le reste du code ne s'exécutera pas tant que l'utilisateur n'aura pas rempli tous les champs
            }

            //VALIDATION 
            //le symbole && signifie "ET", les deux conditions doivent être vraies
            if (utilisateur == "admin" && motDePasse == "admin")
            {
                //Succès: on affiche un message de bienvenue 
                MessageBox.Show($"Bienvenue, {utilisateur}!", "Connexion réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //modification de la navigation 
                this.Hide(); //on cache la fenêtre de connexion

                Form3 f3 = new Form3(); //On créé une instance du formulaire principal (form3) 
                f3.ShowDialog(); //ouverture du tableau de bord 

                //on cache la fenêtre de connexion actuelle 
                this.Close(); //quand l'utilisateur ferme le form3, le code reprendra ici et fermera complètement l'application.
            }
            else
            {
                //échec: on affiche un message d'erreur 
                MessageBox.Show("Identifiant ou mot de passe incorrect.", "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //vide le mdp pour que l'user puisse le retaper 
                        txtMdp.Clear();

                //remet le curseur automatiquement dans la case 
                txtMdp.Focus();
            }
        }

        // généré par le double-clic sur le label inscription dans le designer
        private void lblInscription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) 
        {
            //on créé une instance du formulaire d'inscription (form2)
            Form2 f2 =new Form2();

            //ShowDialog() bloque le Form1 tant que le Form2 n'est pas fermé
            //C'est ce qu'on appelle une fenêtre modale, elle oblige l'utilisateur à interagir avec elle avant de pouvoir revenir à la fenêtre précédente.
            f2.ShowDialog();
        }
    }
}
