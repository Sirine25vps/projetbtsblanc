using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            string sql = "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu FROM PATIENT ORDER BY nom, prenom";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
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
                    patients.Add(p);
                }
            }
            return patients;
        }

        // CRUD : CREATE 
        public int AjouterPatient(Patient p)
        {
            string sql = "INSERT INTO PATIENT (nom, prenom, dateNaissance, numeroSecu) VALUES (@nom, @prenom, @dateNaissance, @numeroSecu); SELECT LAST_INSERT_ID();";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@nom", p.Nom);
                cmd.Parameters.AddWithValue("@prenom", p.Prenom);
                cmd.Parameters.AddWithValue("@dateNaissance", p.DateNaissance);
                cmd.Parameters.AddWithValue("@numeroSecu", p.NumeroSecu);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // CRUD : UPDATE 
        public void ModifierPatient(Patient p)
        {
            string sql = "UPDATE PATIENT SET nom = @nom, prenom = @prenom, dateNaissance = @dateNaissance, numeroSecu = @numeroSecu WHERE numPatient = @id";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@nom", p.Nom);
                cmd.Parameters.AddWithValue("@prenom", p.Prenom);
                cmd.Parameters.AddWithValue("@dateNaissance", p.DateNaissance);
                cmd.Parameters.AddWithValue("@numeroSecu", p.NumeroSecu);

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
            string sql = "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu FROM PATIENT WHERE nom LIKE @motCle ORDER BY nom, prenom";

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
                        patients.Add(p);
                    }
                }
            }
            return patients;
        }

        public List<Patient> RechercherParNom_Vulnerable(string motCle, string libelleAllergie)
        {
            List<Patient> patients = new List<Patient>();
            string sql = "SELECT DISTINCT p.numPatient, p.nom, p.prenom, p.dateNaissance, p.numeroSecu " +
                         "FROM PATIENT p " +
                         "JOIN ETRE_ALLERGIQUE ea ON p.numPatient = ea.numPatient " +
                         "JOIN ALLERGIE a ON a.codeAllergie = ea.codeAllergie " +
                         "WHERE p.nom LIKE '%" + motCle + "%' AND a.libelle = '" + libelleAllergie + "' " +
                         "ORDER BY p.nom, p.prenom";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
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
                    patients.Add(p);
                }
            }
            return patients;
        }

        public Patient ObtenirParId(int id)
        {
            Patient patient = null;
            string sql = "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu FROM PATIENT WHERE numPatient = @id";

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

        

        public List<Patient> RechercherFiltreCombine(string motCle, string libelleAllergie, string numeroSecu)
        {
            List<Patient> patients = new List<Patient>();
            string sql = "SELECT DISTINCT p.numPatient, p.nom, p.prenom, p.dateNaissance, p.numeroSecu FROM PATIENT p ";

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
                        patients.Add(p);
                    }
                }
            }
            return patients;
        }

        public List<Patient> RechercherParNomEtAllergie(string motCle, string libelleAllergie)
        {
            List<Patient> patients = new List<Patient>();
            string sql = "SELECT DISTINCT p.numPatient, p.nom, p.prenom, p.dateNaissance, p.numeroSecu, " +
                         "TIMESTAMPDIFF(YEAR, p.dateNaissance, CURDATE()) AS age FROM PATIENT p ";

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

                        int ageCalcule = lecteur.GetInt32("age");
                        if (p.Nom == "DUPONT" && p.Prenom == "Marie")
                        {
                            MessageBox.Show($"[FLAG D1] L'âge calculé par MySQL pour Marie DUPONT est : {ageCalcule} ans", "Résultat Flag");
                        }
                        patients.Add(p);
                    }
                }
            }
            return patients;
        }
    }
}