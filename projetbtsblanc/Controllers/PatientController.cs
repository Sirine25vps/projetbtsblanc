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
        public void AjouterPatient(Patient p) => _dao.AjouterPatient(p);
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

        internal Patient ObtenirParId(int idPatient)
        {
            throw new NotImplementedException();
        }

        internal object ObtenirHistorique(int idPatient)
        {
            throw new NotImplementedException();
        }
    }
}