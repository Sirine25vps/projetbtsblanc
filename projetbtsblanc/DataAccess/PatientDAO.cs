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

        // CRUD : CREATE --> ajoute un nouveau patient dans la BDD, la méthode retourne l'ID du patient ajouté
        public int AjouterPatient(Patient p)
        {

            // SELECT LAST_INSERT_ID() est utilisé pour récupérer l'ID du dernier enregistrement inséré dans la table PATIENT
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

        // CRUD : UPDATE --> modifie les informations d'un patient existant dans la BDD
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

        //  CRUD : DELETE --> supprime un patient de la BDD en fonction de son ID
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

        // Recherche par nom avec un mot-clé, retourne une liste de patients correspondant au critère
        public List<Patient> RechercherParNom(string motCle)
        {
            List<Patient> patients = new List<Patient>();

            //l'opérateur LIKE permet de chercher des correspondances partielles dans les noms des patients, en utilisant le mot-clé fourni
            string sql = "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu, sexe, pathologies FROM PATIENT WHERE nom LIKE @motCle ORDER BY nom, prenom";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            {

                //les % encadrent le mot clé pour dire à MySQL de chercher le mot clé n'importe où dans le nom du patient
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

        //récupère la fiche complète d'un patient à partir de son ID, y compris ses allergies
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

        // méthode privée (utilisée uniquement par cette classe) pour charger les allergies d'un patient à partir de son ID
        private List<string> ChargerAllergies(int idPatient)
        {
            List<string> allergies = new();
            //jointure sur la table de liaison ETRE_ALLERGIQUE pour récupérer les libellés des allergies associées au patient
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

        // Recherche des patients en combinant un nom et une allergie
        public List<Patient> RechercherParNomEtAllergie(string motCle, string libelleAllergie)
        {
            List<Patient> patients = new List<Patient>();
            string sql = "SELECT DISTINCT p.numPatient, p.nom, p.prenom, p.dateNaissance, p.numeroSecu, p.sexe, p.pathologies " +
                         "FROM PATIENT p ";

            //construction dynamique de la requête SQL : on ajoute des bouts de phrase selon les critères de recherche choisis 
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

        // recherche avancée (nom, allergie, num sécu). Variante de la méthode précédente, avec un paramètre supplémentaire pour le numéro de sécurité sociale
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

        // met à jour la liste des allergies cochées par un patient donné. On utilise la stratégie de suppression des anciennes allergies et d'insertion des nouvelles pour éviter les doublons
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
                // L'utilisation d'un SELECT dans un INSERT permet de récupérer automatiquement l'ID de l'allergie via son nom
                string sqlInsert = "INSERT INTO ETRE_ALLERGIQUE (numPatient, codeAllergie) " +
                                   "SELECT @idPatient, codeAllergie FROM ALLERGIE WHERE libelle = @libelle";

                using (MySqlCommand cmdIns = new MySqlCommand(sqlInsert, cnx))
                {
                    cmdIns.Parameters.AddWithValue("@idPatient", idPatient);
                    
                    // On ajoute le paramètre pour le libellé de l'allergie, qui sera mis à jour dans la boucle ci-des
                    cmdIns.Parameters.Add("@libelle", MySqlDbType.VarChar);

                    // On exécute l'insertion pour chaque allergie cochée
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