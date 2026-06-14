using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projetbtsblanc.Models;
using GSB.Ordonnances.DataAccess;

namespace projetbtsblanc.DataAccess
{
    public class PatientDAO
    {
        public List<Patient> ObtenirTousLesPatients()
        {
            List<Patient> patients = new();
            string sql = "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu, sexe, pathologies FROM PATIENT ORDER BY nom, prenom";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            {
                using (MySqlDataReader lecteur = cmd.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        Patient p = new(
                            lecteur.GetString("nom"),
                            lecteur.GetString("prenom"),
                            lecteur.GetDateTime("dateNaissance"),
                            lecteur.GetString("numeroSecu")
                        );
                        p.Id = lecteur.GetInt32("numPatient");
                        p.Sexe = lecteur["sexe"] != DBNull.Value ? lecteur["sexe"].ToString() : "Non spécifié";
                        p.Pathologies = lecteur["pathologies"] != DBNull.Value ? lecteur["pathologies"].ToString() : "";

                        patients.Add(p);
                    }
                } // Fermeture automatique du DataReader ici
            }

            // Chargement des allergies pour l'affichage dans le tableau
            foreach (var p in patients)
            {
                p.Allergies = ChargerAllergies(p.Id);
            }

            return patients;
        }

        // CRUD : CREATE 
        public int AjouterPatient(Patient p)
        {
            string sql = "INSERT INTO PATIENT (nom, prenom, dateNaissance, numeroSecu, sexe, pathologies) " +
                         "VALUES (@nom, @prenom, @dateNaissance, @numeroSecu, @sexe, @pathologies); SELECT LAST_INSERT_ID();";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@nom", p.Nom);
                cmd.Parameters.AddWithValue("@prenom", p.Prenom);
                cmd.Parameters.AddWithValue("@dateNaissance", p.DateNaissance);
                cmd.Parameters.AddWithValue("@numeroSecu", p.NumeroSecu);
                cmd.Parameters.AddWithValue("@sexe", p.Sexe);
                cmd.Parameters.AddWithValue("@pathologies", p.Pathologies);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // CRUD : UPDATE 
        public void ModifierPatient(Patient p)
        {
            string sql = "UPDATE PATIENT SET nom = @nom, prenom = @prenom, dateNaissance = @dateNaissance, " +
                         "numeroSecu = @numeroSecu, sexe = @sexe, pathologies = @pathologies " +
                         "WHERE numPatient = @id";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@nom", p.Nom);
                cmd.Parameters.AddWithValue("@prenom", p.Prenom);
                cmd.Parameters.AddWithValue("@dateNaissance", p.DateNaissance);
                cmd.Parameters.AddWithValue("@numeroSecu", p.NumeroSecu);
                cmd.Parameters.AddWithValue("@sexe", p.Sexe);
                cmd.Parameters.AddWithValue("@pathologies", p.Pathologies);

                cmd.ExecuteNonQuery();
            }
        }

        //  CRUD : DELETE 
        public void SupprimerPatient(int id)
        {
            string sql = "DELETE FROM PATIENT WHERE numPatient = @id";
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Patient> RechercherParNom(string motCle)
        {
            List<Patient> patients = new List<Patient>();
            string sql = "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu, sexe, pathologies FROM PATIENT WHERE nom LIKE @motCle ORDER BY nom, prenom";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@motCle", "%" + motCle + "%");
                using (MySqlDataReader lecteur = cmd.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        Patient p = new Patient(
                            lecteur.GetString("nom"),
                            lecteur.GetString("prenom"),
                            lecteur.GetDateTime("dateNaissance"),
                            lecteur.GetString("numeroSecu")
                        );
                        p.Id = lecteur.GetInt32("numPatient");
                        p.Sexe = lecteur["sexe"] != DBNull.Value ? lecteur["sexe"].ToString() : "Non spécifié";
                        p.Pathologies = lecteur["pathologies"] != DBNull.Value ? lecteur["pathologies"].ToString() : "";

                        patients.Add(p);
                    }
                }
            }

            // Chargement des allergies
            foreach (var p in patients) p.Allergies = ChargerAllergies(p.Id);

            return patients;
        }

        public Patient ObtenirParId(int id)
        {
            Patient patient = null;
            string sql = "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu, sexe, pathologies FROM PATIENT WHERE numPatient = @id";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        patient = new Patient(
                            r.GetString("nom"),
                            r.GetString("prenom"),
                            r.GetDateTime("dateNaissance"),
                            r.GetString("numeroSecu")
                        );
                        patient.Id = r.GetInt32("numPatient");
                        patient.Sexe = r["sexe"] != DBNull.Value ? r["sexe"].ToString() : "Non spécifié";
                        patient.Pathologies = r["pathologies"] != DBNull.Value ? r["pathologies"].ToString() : "";
                    }
                }
            }

            if (patient != null)
            {
                patient.Allergies = ChargerAllergies(id);
            }
            return patient;
        }

        private List<string> ChargerAllergies(int idPatient)
        {
            List<string> allergies = new();
            string sql = "SELECT a.libelle FROM ETRE_ALLERGIQUE ea " +
                         "JOIN ALLERGIE a ON a.codeAllergie = ea.codeAllergie " +
                         "WHERE ea.numPatient = @id ORDER BY a.libelle";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@id", idPatient);
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        allergies.Add(r.GetString("libelle"));
                    }
                }
            }
            return allergies;
        }

        public List<Patient> RechercherParNomEtAllergie(string motCle, string libelleAllergie)
        {
            List<Patient> patients = new List<Patient>();
            string sql = "SELECT DISTINCT p.numPatient, p.nom, p.prenom, p.dateNaissance, p.numeroSecu, p.sexe, p.pathologies " +
                         "FROM PATIENT p ";

            if (libelleAllergie != null)
            {
                sql += "JOIN ETRE_ALLERGIQUE ea ON p.numPatient = ea.numPatient " +
                       "JOIN ALLERGIE a ON a.codeAllergie = ea.codeAllergie ";
            }
            sql += "WHERE p.nom LIKE @motCle ";
            if (libelleAllergie != null) sql += "AND a.libelle = @libelleAllergie ";
            sql += "ORDER BY p.nom, p.prenom";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@motCle", "%" + motCle + "%");
                if (libelleAllergie != null) cmd.Parameters.AddWithValue("@libelleAllergie", libelleAllergie);

                using (MySqlDataReader lecteur = cmd.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        Patient p = new Patient(
                            lecteur.GetString("nom"),
                            lecteur.GetString("prenom"),
                            lecteur.GetDateTime("dateNaissance"),
                            lecteur.GetString("numeroSecu")
                        );
                        p.Id = lecteur.GetInt32("numPatient");
                        p.Sexe = lecteur["sexe"] != DBNull.Value ? lecteur["sexe"].ToString() : "Non spécifié";
                        p.Pathologies = lecteur["pathologies"] != DBNull.Value ? lecteur["pathologies"].ToString() : "";

                        patients.Add(p);
                    }
                }
            }

            // L'étape cruciale pour que le tableau affiche les allergies des patients trouvés
            foreach (var p in patients)
            {
                p.Allergies = ChargerAllergies(p.Id);
            }

            return patients;
        }

        // J'ai également corrigé le filtre combiné au cas où tu en aurais besoin
        public List<Patient> RechercherFiltreCombine(string motCle, string libelleAllergie, string numeroSecu)
        {
            List<Patient> patients = new List<Patient>();
            string sql = "SELECT DISTINCT p.numPatient, p.nom, p.prenom, p.dateNaissance, p.numeroSecu, p.sexe, p.pathologies FROM PATIENT p ";

            if (libelleAllergie != null)
            {
                sql += "JOIN ETRE_ALLERGIQUE ea ON p.numPatient = ea.numPatient " +
                       "JOIN ALLERGIE a ON a.codeAllergie = ea.codeAllergie ";
            }
            sql += "WHERE p.nom LIKE @motCle ";

            if (libelleAllergie != null) sql += "AND a.libelle = @libelleAllergie ";
            if (!string.IsNullOrWhiteSpace(numeroSecu)) sql += "AND p.numeroSecu LIKE @numeroSecu ";

            sql += "ORDER BY p.nom, p.prenom";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@motCle", "%" + motCle + "%");
                if (libelleAllergie != null) cmd.Parameters.AddWithValue("@libelleAllergie", libelleAllergie);
                if (!string.IsNullOrWhiteSpace(numeroSecu)) cmd.Parameters.AddWithValue("@numeroSecu", numeroSecu + "%");

                using (MySqlDataReader lecteur = cmd.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        Patient p = new Patient(
                            lecteur.GetString("nom"),
                            lecteur.GetString("prenom"),
                            lecteur.GetDateTime("dateNaissance"),
                            lecteur.GetString("numeroSecu")
                        );
                        p.Id = lecteur.GetInt32("numPatient");
                        p.Sexe = lecteur["sexe"] != DBNull.Value ? lecteur["sexe"].ToString() : "Non spécifié";
                        p.Pathologies = lecteur["pathologies"] != DBNull.Value ? lecteur["pathologies"].ToString() : "";

                        patients.Add(p);
                    }
                }
            }

            // Chargement des allergies
            foreach (var p in patients) p.Allergies = ChargerAllergies(p.Id);

            return patients;
        }

        // NOUVELLE MÉTHODE : Met à jour les liens dans la table ETRE_ALLERGIQUE
        public void MettreAJourAllergies(int idPatient, List<string> libellesAllergies)
        {
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                // 1. On supprime les anciennes allergies du patient pour repartir à zéro
                string sqlDelete = "DELETE FROM ETRE_ALLERGIQUE WHERE numPatient = @idPatient";
                using (MySqlCommand cmdDel = new MySqlCommand(sqlDelete, cnx))
                {
                    cmdDel.Parameters.AddWithValue("@idPatient", idPatient);
                    cmdDel.ExecuteNonQuery();
                }

                // 2. S'il n'y a pas de nouvelles allergies à cocher, on s'arrête là
                if (libellesAllergies == null || libellesAllergies.Count == 0) return;

                // 3. On insère les nouvelles allergies cochées
                string sqlInsert = "INSERT INTO ETRE_ALLERGIQUE (numPatient, codeAllergie) " +
                                   "SELECT @idPatient, codeAllergie FROM ALLERGIE WHERE libelle = @libelle";

                using (MySqlCommand cmdIns = new MySqlCommand(sqlInsert, cnx))
                {
                    cmdIns.Parameters.AddWithValue("@idPatient", idPatient);
                    // On prépare le paramètre libelle qu'on va changer dans la boucle
                    cmdIns.Parameters.Add("@libelle", MySqlDbType.VarChar);

                    foreach (string libelle in libellesAllergies)
                    {
                        cmdIns.Parameters["@libelle"].Value = libelle;
                        cmdIns.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}