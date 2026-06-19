using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GSB.Ordonnances.DataAccess;

namespace projetbtsblanc.Controllers
{
    //contrôleur en charge de la gestion des données liées aux allergies
    //fait le lien entre l'interface utilisateur et l'accès aux données
    public class AllergieController 
        
    {
        // Récupère la liste complète des allergies pour le menu déroulant
        //liste de chaines de caractères (string) représentant les nom des allergies
        public List<string> ObtenirLibelles()
        {
            List<string> libelles = new();

            //requête SQL ciblée : on ne sélectionne que la colonne utile, triée de A à Z 
            string sql = "SELECT libelle FROM ALLERGIE ORDER BY libelle";

            //l'encapsulation dans des blocs "using" est une bonne pratique qui permet de garantir la fermerture propre de la connexion et la libération de la mémoire dès qu'on sort du bloc, même si la requête plante en plein milieu
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            using (MySqlDataReader lecteur = cmd.ExecuteReader())
            {
                //parcours ligne par ligne des résultats renvoyés par le serveur MySQL
                while (lecteur.Read())
                {
                    libelles.Add(lecteur.GetString("libelle"));
                }
            }
            return libelles;
        }
    }
}