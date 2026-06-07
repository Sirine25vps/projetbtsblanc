using System.Collections.Generic;
using projetbtsblanc.Models;
using projetbtsblanc.DataAccess;

namespace projetbtsblanc.Controllers
{
    public class MedecinController
    {
        private MedecinDAO _dao = new();
        public List<Medecin> ObtenirTousLesMedecins() => _dao.ObtenirTousLesMedecins();
    }
}