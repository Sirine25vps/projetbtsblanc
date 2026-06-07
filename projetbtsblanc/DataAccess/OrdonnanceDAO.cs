using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projetbtsblanc.Models;
using GSB.Ordonnances.DataAccess;

namespace projetbtsblanc.DataAccess
{
    public class OrdonnanceDAO
    {
        // Enregistrement d'une ordonnance avec transaction 
        public void EnregistrerOrdonnance(Ordonnance ordonnance)
        {
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                MySqlTransaction transaction = cnx.BeginTransaction();

                try
                {
                    // Insertion de l'en-tête
                    string sqlOrdonnance = "INSERT INTO ORDONNANCE (dateEmission, numMedecin, numPatient) VALUES (@date, @idMed, @idPat); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmdOrdo = new(sqlOrdonnance, cnx, transaction);
                    cmdOrdo.Parameters.AddWithValue("@date", ordonnance.DateEmission);
                    cmdOrdo.Parameters.AddWithValue("@idMed", ordonnance.Medecin.Id);
                    cmdOrdo.Parameters.AddWithValue("@idPat", ordonnance.Patient.Id);

                    int idOrdo = Convert.ToInt32(cmdOrdo.ExecuteScalar());

                    // Insertion des lignes
                    foreach (var medoc in ordonnance.Medicaments)
                    {
                        string sqlLigne = "INSERT INTO CONTENIR (numOrdonnance, codeMedicament, quantite) VALUES (@idOrdo, @codeMed, @qte)";
                        MySqlCommand cmdLigne = new(sqlLigne, cnx, transaction);
                        cmdLigne.Parameters.AddWithValue("@idOrdo", idOrdo);
                        cmdLigne.Parameters.AddWithValue("@codeMed", medoc.CodeMedicament);
                        cmdLigne.Parameters.AddWithValue("@qte", 1);
                        cmdLigne.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // Liste globale des ordonnances
        public List<Ordonnance> ObtenirToutes()
        {
            List<Ordonnance> liste = new();
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                string sql = "SELECT * FROM ORDONNANCE";
                MySqlCommand cmd = new(sql, cnx);

                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        liste.Add(new Ordonnance
                        {
                            Id = r.GetInt32("numOrdonnance"),
                            DateEmission = r.GetDateTime("dateEmission")
                        });
                    }
                }
            }
            return liste;
        }

        // Détails des médicaments 
        public List<Medicament> ObtenirMedicamentsParOrdonnance(int idOrdonnance)
        {
            List<Medicament> liste = new();
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                // Requête SQL avec jointure pour récupérer les infos du médicament
                string sql = "SELECT m.codeMedicament, m.nom, m.dosage, m.unite FROM CONTENIR c JOIN MEDICAMENT m ON c.codeMedicament = m.codeMedicament WHERE c.numOrdonnance = @id";
                MySqlCommand cmd = new(sql, cnx);
                cmd.Parameters.AddWithValue("@id", idOrdonnance);

                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        liste.Add(new Medicament(
                            r.GetString("codeMedicament"),
                            r.GetString("nom"),
                            r.GetString("dosage"),
                            r.GetString("unite")
                        ));
                    }
                }
            }
            return liste;
        }
    }
}