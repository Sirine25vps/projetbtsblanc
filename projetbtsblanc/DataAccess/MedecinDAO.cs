using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projetbtsblanc.Models;
using GSB.Ordonnances.DataAccess; 

namespace projetbtsblanc.DataAccess
{
    public class MedecinDAO
    {
        public List<Medecin> ObtenirTousLesMedecins()
        {
            List<Medecin> liste = new();
            string sql = "SELECT nom, prenom, dateNaissance, numeroRPPS, specialite FROM MEDECIN";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            using (MySqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    liste.Add(new Medecin(
                        r.GetString("nom"),
                        r.GetString("prenom"),
                        r.GetDateTime("dateNaissance"),
                        r.GetString("numeroRPPS"),
                        r.GetString("specialite")
                    ));
                }
            }
            return liste;
        }
    }
}