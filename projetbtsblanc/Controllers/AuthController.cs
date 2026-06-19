using GSB.Ordonnances.DataAccess;
using MySql.Data.MySqlClient;
using projetbtsblanc.DataAccess;
using System;

namespace projetbtsblanc.Controllers
{
    //gère la sécurité et la connexion des utilisateurs à l'application
    public class AuthController
    {
        //vérifie si l'utilisateur existe dans la base de données avec les bons identifiants
        public bool SeConnecter(string login, string password)
        {
            // requête simple pour vérifier le login/mdp 
            // bloc "using" ouvre la connexion à la base de données et la referme tout seul à la fin quoi qu'il arrive 
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                //on demande à mysql de compter combien de lignes correspondent à ce login et ce mot de passe
                string sql = "SELECT COUNT(*) FROM UTILISATEUR WHERE login = @login AND password = @password";

                //on prépare la commande pour qu'elle soit exécutée 
                MySqlCommand cmd = new(sql, cnx);

                //on remplace les "@..." par les mots tapés par l'utilisateur 
                //faire ça permet d'éviter les injections SQL (un utilisateur malveillant qui taperait du code SQL dans le champ login ou password)
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);

                //si total > 0 alors l'utilisateur existe et se connecte sinon c'est faux l'accès est refusé
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}