using projetbtsblanc.DataAccess;
using projetbtsblanc.Models;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace projetbtsblanc.Controllers
{
    // Fait le pont entre l'interface visuelle et la base de données pour tout ce qui concerne les ordonnances.
    public class OrdonnanceController
    {
        //prépare le DAO qui va dialoguer avec la base de données
        private OrdonnanceDAO _dao = new();

        // envoie une nouvelle ordonnance au DAO pour qu'il l'enregistre dans la base de données
        public void EnregistrerOrdonnance(Ordonnance o)
        {
            _dao.EnregistrerOrdonnance(o);
        }

        // demande au DAO de récupérer toutes les ordonnances existantes dans la BDD
        public List<Ordonnance> ObtenirToutesLesOrdonnances()
        {
            return _dao.ObtenirToutes();
        }

        // Obtenir uniquement les médicaments d'une ordonnance précise
        public List<Medicament> ObtenirMedicamentsDuneOrdonnance(int idOrdonnance)
        {
            
            return _dao.ObtenirMedicamentsParOrdonnance(idOrdonnance);
        }
        //demande au DAO de récupérer toutes les lignes de prescription d'une ordonnance précise pour l'afficher dans le tableau 
        public List<LignePrescription> ObtenirLignes(int idOrdonnance)
        {
            return _dao.ObtenirLignes(idOrdonnance);
        }
        //demande au DAO de récupérer toutes les ordonnances d'un patient précis pour l'afficher dans le tableau
        public List<Ordonnance> ObtenirOrdonnancesParPatient(int idPatient)
        {
            return _dao.ObtenirParPatient(idPatient);
        }
    }
}