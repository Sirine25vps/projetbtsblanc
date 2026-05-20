using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GSB.Ordonnances.DataAccess;
using projetbtsblanc.Models;
namespace projetbtsblanc.Controllers
{
    public class PatientController
    {
        /// <summary>
        /// Récupère tous les patients de la base, triés par nom puis prénom.
        /// </summary>
        public List<Patient> ObtenirTousLesPatients()


        {
            List<Patient> patients = new List<Patient>();
            string sql = "SELECT numPatient, nom, prenom, " +
            " dateNaissance, numeroSecu " +
            "FROM PATIENT " +
            "ORDER BY nom, prenom";
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
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
        /// <summary>
        /// Récupère les patients dont le nom OU le prénom
        /// contient le mot-clé donné.
        /// </summary>
        public List<Patient> RechercherParNom(string motCle)
        {
            List<Patient> patients = new List<Patient>();
            string sql = "SELECT numPatient, nom, prenom, " +
            " dateNaissance, numeroSecu " +
            "FROM PATIENT " +
            "WHERE nom LIKE @motCle " +
            " OR prenom LIKE @motCle " +
            "ORDER BY nom, prenom";
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                // Les % autour permettent une recherche "contient" :
                // motCle = "dup" -> cherche "%dup%"
                // correspond à DUPONT, DUPUIS, MARDUPLAT, etc.
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
        /// <summary>
        /// Récupère un patient par son identifiant.
        /// Retourne null si l'ID n'existe pas.
        /// </summary>
        public Patient ObtenirParId(int id)
        {
            Patient patient = null;
            string sql = "SELECT numPatient, nom, prenom, " +
            " dateNaissance, numeroSecu " +
            "FROM PATIENT " +
            "WHERE numPatient = @id";
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read()) // au plus une ligne attendue
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
            // Une fois le patient construit, on charge ses allergies
            if (patient != null)
            {
                patient.Allergies = ChargerAllergies(id);
            }
            return patient;
        }

        /// <summary>
        /// Retourne la liste des libellés d'allergies pour un patient.
        /// Méthode privée : utilitaire interne au contrôleur.
        /// </summary>
        private List<string> ChargerAllergies(int idPatient)
        {
            List<string> allergies = new List<string>();
            string sql = "SELECT a.libelle " +
            "FROM ETRE_ALLERGIQUE ea " +
            "JOIN ALLERGIE a " +
            " ON a.codeAllergie = ea.codeAllergie " +
            "WHERE ea.numPatient = @id " +
            "ORDER BY a.libelle";
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@id", idPatient);
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        allergies.Add(r.GetString("libelle"));
                } 
            } 
            return allergies;
        } // accolade de fin de la méthode ChargerAllergies

        /// <summary>
        /// Liste les ordonnances d'un patient, classées de la plus
        /// récente à la plus ancienne.
        /// </summary>
        public List<OrdonnanceResume> ObtenirHistorique(int idPatient)
        {
            List<OrdonnanceResume> historique = new List<OrdonnanceResume>();
            string sql = "SELECT o.numOrdonnance, o.dateEmission, " +
            " m.nom AS medecinNom, " +
            " m.specialite AS medecinSpecialite " +
            "FROM ORDONNANCE o " +
            "JOIN MEDECIN m ON m.numMedecin = o.numMedecin " +
            "WHERE o.numPatient = @id " +
            "ORDER BY o.dateEmission DESC";
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@id", idPatient);
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        historique.Add(new OrdonnanceResume
                        {
                            Id = r.GetInt32("numOrdonnance"),
                            DateEmission = r.GetDateTime("dateEmission"),
                            MedecinNom = r.GetString("medecinNom"),
                            MedecinSpecialite = r.GetString("medecinSpecialite")
                        });
                    }
                }
            }
            return historique;
        } //accolade de fin de la méthode ObtenirHistorique
    } // accolade de fin de la classe PatientController
} //accolade de fin du namespace