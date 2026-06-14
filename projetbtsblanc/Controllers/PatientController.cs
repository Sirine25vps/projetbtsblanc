using System;
using System.Collections.Generic;
using projetbtsblanc.Models;
using projetbtsblanc.DataAccess;

namespace projetbtsblanc.Controllers
{
    public class PatientController
    {
        private PatientDAO _dao = new();

        public List<Patient> ObtenirTousLesPatients() => _dao.ObtenirTousLesPatients();

        // CORRIGÉ : Modifié pour retourner un 'int' au lieu de 'void'
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

        // délègue au DAO
        public Patient ObtenirParId(int idPatient)
        {
            return _dao.ObtenirParId(idPatient);
        }

        // retourne l'historique des ordonnances du patient
        public List<Ordonnance> ObtenirHistorique(int idPatient)
        {
            projetbtsblanc.DataAccess.OrdonnanceDAO ordoDao = null;
            try
            {
                ordoDao = new projetbtsblanc.DataAccess.OrdonnanceDAO();
                return ordoDao.ObtenirParPatient(idPatient);
            }
            catch (NotImplementedException nie)
            {
                // Fournir plus de contexte pour diagnostiquer l'origine du NotImplementedException
                string typeInfo = ordoDao == null ? "(instanciation échouée)" : ordoDao.GetType().FullName + " - " + ordoDao.GetType().Assembly.FullName;
                throw new NotImplementedException($"La méthode ObtenirParPatient n'est pas implémentée. Type réel: {typeInfo}", nie);
            }
        }
    }
}