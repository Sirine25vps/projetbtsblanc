using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projetbtsblanc.Models;
using GSB.Ordonnances.DataAccess;

namespace projetbtsblanc.DataAccess
{
    public class MedicamentDAO
    {
        public List<Medicament> ObtenirTousLesMedicaments()
        {
            List<Medicament> liste = new();

           
            string sql = "SELECT codeMedicament, nom, dosage, unite FROM MEDICAMENT";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            using (MySqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    liste.Add(new Medicament(
                        r["codeMedicament"] != DBNull.Value ? r["codeMedicament"].ToString() : "",
                        r["nom"] != DBNull.Value ? r["nom"].ToString() : "",
                        // Lecture sécurisée : empêche le plantage si la case est vide
                        r["dosage"] != DBNull.Value ? r["dosage"].ToString() : "",
                        r["unite"] != DBNull.Value ? r["unite"].ToString() : ""
                    ));
                }
            }
            return liste;
        }
    }
}