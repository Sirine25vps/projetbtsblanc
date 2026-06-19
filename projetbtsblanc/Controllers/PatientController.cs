using System;
using System.Collections.Generic;
using projetbtsblanc.Models;
using projetbtsblanc.DataAccess;

namespace projetbtsblanc.Controllers
{
    //Fait le pont entre l'interface visuelle et la BDD pour gérer les patients
    public class PatientController
    {
        //// On prépare le DAO qui dialogue avec la BDD pour les patients
        private PatientDAO _dao = new();

        //demande au DAO de récupérer la liste complete des patients
        public List<Patient> ObtenirTousLesPatients() => _dao.ObtenirTousLesPatients();

        // envoie un nouveau patient au DAO pour l'ajouter dans la BDD et renvoie un "int" qui correspond à l'ID du patient qui vient d'être créé dans la BDD
        public int AjouterPatient(Patient p) => _dao.AjouterPatient(p);

        public void ModifierPatient(Patient p) => _dao.ModifierPatient(p);
        public void SupprimerPatient(int id) => _dao.SupprimerPatient(id);

        public List<Patient> RechercherParNom(string motCle)
        {
            return _dao.RechercherParNom(motCle);
        }
        public List<Patient> RechercherParNomEtAllergie(string motCle, string allergie)
        {
            return _dao.RechercherParNomEtAllergie(motCle, allergie);
        }

        // Fait le pont entre la vue et le DAO
        public void MettreAJourAllergies(int idPatient, List<string> libellesAllergies)
        {
            _dao.MettreAJourAllergies(idPatient, libellesAllergies);
        }

        // Demande au DAO de récupérer la fiche complète d'un seul patient grâce à son ID
        public Patient ObtenirParId(int idPatient)
        {
            return _dao.ObtenirParId(idPatient);
        }

        // retourne l'historique des ordonnances du patient
        public List<Ordonnance> ObtenirHistorique(int idPatient)
        {
            projetbtsblanc.DataAccess.OrdonnanceDAO ordoDao = null;

            //Le bloc "try/catch" est un filet de sécurité.
            // On "essaie" (try) d'exécuter le code. Si ça plante, on "attrape" (catch) l'erreur pour éviter que l'application entière se ferme brutalement
            try
            {
                ordoDao = new projetbtsblanc.DataAccess.OrdonnanceDAO();
                return ordoDao.ObtenirParPatient(idPatient);
            }
            catch (NotImplementedException nie)
            {
                // Si le code plante parce que la méthode n'est pas encore finie d'être codée, on prépare un message d'erreur détaillé pour le développeur
                string typeInfo = ordoDao == null ? "(instanciation échouée)" : ordoDao.GetType().FullName + " - " + ordoDao.GetType().Assembly.FullName;
                throw new NotImplementedException($"La méthode ObtenirParPatient n'est pas implémentée. Type réel: {typeInfo}", nie);
            }
        }
    }
}