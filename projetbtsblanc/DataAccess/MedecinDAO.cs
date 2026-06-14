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
            string sql = "SELECT numMedecin, nom, prenom, dateNaissance, numeroRPPS, specialite FROM MEDECIN";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            using (MySqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Medecin m = new Medecin(
                        r.GetString("nom"),
                        r.GetString("prenom"),
                        r.GetDateTime("dateNaissance"),
                        r.GetString("numeroRPPS"),
                        r["specialite"] != DBNull.Value ? r["specialite"].ToString() : ""
                    );
                    m.Id = r.GetInt32("numMedecin"); // ← c'est ça qui manquait !
                    liste.Add(m);
                }
            }
            return liste;
        }
    }
}