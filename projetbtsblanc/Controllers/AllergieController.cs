using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GSB.Ordonnances.DataAccess;

namespace projetbtsblanc.Controllers
{
    public class AllergieController
    {
        // Récupère la liste complète des allergies pour le menu déroulant
        public List<string> ObtenirLibelles()
        {
            List<string> libelles = new();
            string sql = "SELECT libelle FROM ALLERGIE ORDER BY libelle";
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            using (MySqlDataReader lecteur = cmd.ExecuteReader())
            {
                while (lecteur.Read())
                {
                    libelles.Add(lecteur.GetString("libelle"));
                }
            }
            return libelles;
        }
    }
}