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
                    string sqlOrdonnance = "INSERT INTO ORDONNANCE (dateEmission, numMedecin, numPatient) " +
                                           "VALUES (@date, @idMed, @idPat); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmdOrdo = new(sqlOrdonnance, cnx, transaction);
                    cmdOrdo.Parameters.AddWithValue("@date", ordonnance.DateEmission);
                    cmdOrdo.Parameters.AddWithValue("@idMed", ordonnance.Medecin.Id);
                    cmdOrdo.Parameters.AddWithValue("@idPat", ordonnance.Patient.Id);

                    int idOrdo = Convert.ToInt32(cmdOrdo.ExecuteScalar());

                    // Insertion des lignes de prescription
                    foreach (var medoc in ordonnance.Medicaments)
                    {
                        string sqlLigne = "INSERT INTO CONTENIR (numOrdonnance, codeMedicament, posologie, dureeJours) " +
                                          "VALUES (@idOrdo, @codeMed, @posologie, @duree)";
                        MySqlCommand cmdLigne = new(sqlLigne, cnx, transaction);
                        cmdLigne.Parameters.AddWithValue("@idOrdo", idOrdo);
                        cmdLigne.Parameters.AddWithValue("@codeMed", medoc.CodeMedicament);
                        cmdLigne.Parameters.AddWithValue("@posologie",
                            !string.IsNullOrWhiteSpace(medoc.Dosage) ? medoc.Dosage : "1 matin et soir");
                        cmdLigne.Parameters.AddWithValue("@duree", 7);
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
                string sql = "SELECT o.numOrdonnance, o.dateEmission, " +
                             "p.numPatient, p.nom, p.prenom, " +
                             "m.numMedecin, m.nom AS nomMedecin " +
                             "FROM ORDONNANCE o " +
                             "JOIN PATIENT p ON o.numPatient = p.numPatient " +
                             "JOIN MEDECIN m ON o.numMedecin = m.numMedecin " +
                             "ORDER BY o.dateEmission DESC";
                MySqlCommand cmd = new(sql, cnx);

                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Ordonnance ordo = new Ordonnance
                        {
                            Id = r.GetInt32("numOrdonnance"),
                            DateEmission = r.IsDBNull(r.GetOrdinal("dateEmission"))
                                ? DateTime.MinValue
                                : r.GetDateTime("dateEmission"),
                            Patient = new Patient(
                                r.GetString("nom"),
                                r.GetString("prenom"),
                                DateTime.MinValue,
                                ""
                            )
                            { Id = r.GetInt32("numPatient") },
                            Medecin = new Medecin
                            {
                                Id = r.GetInt32("numMedecin"),
                                Nom = r.GetString("nomMedecin")
                            }
                        };
                        liste.Add(ordo);
                    }
                }
            }
            return liste;
        }

        // Détails des médicaments d'une ordonnance
        public List<Medicament> ObtenirMedicamentsParOrdonnance(int idOrdonnance)
        {
            List<Medicament> liste = new();
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                string sql = "SELECT m.codeMedicament, m.nom, c.posologie, m.unite " +
                             "FROM CONTENIR c " +
                             "JOIN MEDICAMENT m ON c.codeMedicament = m.codeMedicament " +
                             "WHERE c.numOrdonnance = @id";
                MySqlCommand cmd = new(sql, cnx);
                cmd.Parameters.AddWithValue("@id", idOrdonnance);

                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        liste.Add(new Medicament(
                            r["codeMedicament"].ToString(),
                            r["nom"] != DBNull.Value ? r["nom"].ToString() : "",
                            r["posologie"] != DBNull.Value ? r["posologie"].ToString() : "",
                            r["unite"] != DBNull.Value ? r["unite"].ToString() : ""
                        ));
                    }
                }
            }
            return liste;
        }

        // Obtenir une ordonnance par son ID
        public Ordonnance ObtenirParId(int id)
        {
            Ordonnance ordo = null;
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                string sql = "SELECT o.numOrdonnance, o.dateEmission, " +
                             "p.numPatient, p.nom, p.prenom, " +
                             "m.numMedecin, m.nom AS nomMedecin " +
                             "FROM ORDONNANCE o " +
                             "JOIN PATIENT p ON o.numPatient = p.numPatient " +
                             "JOIN MEDECIN m ON o.numMedecin = m.numMedecin " +
                             "WHERE o.numOrdonnance = @id";
                MySqlCommand cmd = new(sql, cnx);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        ordo = new Ordonnance
                        {
                            Id = r.GetInt32("numOrdonnance"),
                            DateEmission = r.IsDBNull(r.GetOrdinal("dateEmission"))
                                ? DateTime.MinValue
                                : r.GetDateTime("dateEmission"),
                            Patient = new Patient(
                                r.GetString("nom"),
                                r.GetString("prenom"),
                                DateTime.MinValue,
                                ""
                            )
                            { Id = r.GetInt32("numPatient") },
                            Medecin = new Medecin
                            {
                                Id = r.GetInt32("numMedecin"),
                                Nom = r.GetString("nomMedecin")
                            }
                        };
                    }
                }
            }

            if (ordo != null)
                ordo.Medicaments = ObtenirMedicamentsParOrdonnance(id);

            return ordo;
        }

        // Supprimer une ordonnance (et ses lignes via cascade ou manuellement)
        public void SupprimerOrdonnance(int id)
        {
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                MySqlTransaction transaction = cnx.BeginTransaction();
                try
                {
                    // Supprimer d'abord les lignes contenir
                    string sqlLignes = "DELETE FROM CONTENIR WHERE numOrdonnance = @id";
                    MySqlCommand cmdLignes = new(sqlLignes, cnx, transaction);
                    cmdLignes.Parameters.AddWithValue("@id", id);
                    cmdLignes.ExecuteNonQuery();

                    // Puis supprimer l'ordonnance
                    string sqlOrdo = "DELETE FROM ORDONNANCE WHERE numOrdonnance = @id";
                    MySqlCommand cmdOrdo = new(sqlOrdo, cnx, transaction);
                    cmdOrdo.Parameters.AddWithValue("@id", id);
                    cmdOrdo.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // Obtenir toutes les ordonnances d'un patient
        public List<Ordonnance> ObtenirParPatient(int idPatient)
        {
            List<Ordonnance> liste = new();
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                string sql = "SELECT o.numOrdonnance, o.dateEmission, " +
                             "p.numPatient, p.nom, p.prenom, " +
                             "m.numMedecin, m.nom AS nomMedecin " +
                             "FROM ORDONNANCE o " +
                             "JOIN PATIENT p ON o.numPatient = p.numPatient " +
                             "JOIN MEDECIN m ON o.numMedecin = m.numMedecin " +
                             "WHERE o.numPatient = @id " +
                             "ORDER BY o.dateEmission DESC";
                MySqlCommand cmd = new(sql, cnx);
                cmd.Parameters.AddWithValue("@id", idPatient);

                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Ordonnance ordo = new Ordonnance
                        {
                            Id = r.GetInt32("numOrdonnance"),
                            DateEmission = r.IsDBNull(r.GetOrdinal("dateEmission"))
                                ? DateTime.MinValue
                                : r.GetDateTime("dateEmission"),
                            Patient = new Patient(
                                r.GetString("nom"),
                                r.GetString("prenom"),
                                DateTime.MinValue,
                                ""
                            )
                            { Id = r.GetInt32("numPatient") },
                            Medecin = new Medecin
                            {
                                Id = r.GetInt32("numMedecin"),
                                Nom = r.GetString("nomMedecin")
                            }
                        };
                        liste.Add(ordo);
                    }
                }
            }

            // Remplir les médicaments pour chaque ordonnance
            foreach (var ordo in liste)
            {
                ordo.Medicaments = ObtenirMedicamentsParOrdonnance(ordo.Id);
            }

            return liste;
        }

        // Nouvelle méthode : Obtenir les lignes de prescription formatées pour l'affichage
        public List<LignePrescription> ObtenirLignes(int idOrdonnance)
        {
            List<LignePrescription> lesLignes = new List<LignePrescription>();

            string sql = "SELECT c.posologie, c.dureeJours, m.nom " +
                         "FROM CONTENIR c " +
                         "JOIN MEDICAMENT m ON c.codeMedicament = m.codeMedicament " +
                         "WHERE c.numOrdonnance = @id";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@id", idOrdonnance);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lesLignes.Add(new LignePrescription(
                            reader.GetString("nom"),
                            reader.GetString("posologie"),
                            reader.GetInt32("dureeJours")
                        ));
                    }
                }
            }
            return lesLignes;
        }
    }
}