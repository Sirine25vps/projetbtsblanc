using System.Collections.Generic;
using projetbtsblanc.Models;
using projetbtsblanc.DataAccess;

namespace projetbtsblanc.Controllers
{
    public class MedecinController
    {
        //Fait le pont entre l'interface (les vues) et la base de données (le DAO) concernant les médecins.
        private MedecinDAO _dao = new();

        //demande au DAO de récupérer la liste complète des médecins
        // symbole => est un raccourci en écriture C#
        // c'est pareil que d'écrire { return _dao.ObtenirTousLesMedecins(); }
        public List<Medecin> ObtenirTousLesMedecins() => _dao.ObtenirTousLesMedecins();
    }
}