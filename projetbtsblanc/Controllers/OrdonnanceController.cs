using System.Collections.Generic;
using projetbtsblanc.Models;
using projetbtsblanc.DataAccess;

namespace projetbtsblanc.Controllers
{
    public class OrdonnanceController
    {
        private OrdonnanceDAO _dao = new();

        // Enregistre une nouvelle ordonnance
        public void EnregistrerOrdonnance(Ordonnance o)
        {
            _dao.EnregistrerOrdonnance(o);
        }

        // Obtenir la liste globale de toutes les ordonnances
        public List<Ordonnance> ObtenirToutesLesOrdonnances()
        {
            return _dao.ObtenirToutes();
        }

        // Obtenir uniquement les médicaments d'une ordonnance précise
        public List<Medicament> ObtenirMedicamentsDuneOrdonnance(int idOrdonnance)
        {
            
            return _dao.ObtenirMedicamentsParOrdonnance(idOrdonnance);
        }
        public List<LignePrescription> ObtenirLignes(int idOrdonnance)
        {
            return _dao.ObtenirLignes(idOrdonnance);
        }
        public List<Ordonnance> ObtenirOrdonnancesParPatient(int idPatient)
        {
            return _dao.ObtenirParPatient(idPatient);
        }
    }
}