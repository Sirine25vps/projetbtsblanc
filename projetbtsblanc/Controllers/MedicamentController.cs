using System.Collections.Generic;
using projetbtsblanc.Models;
using projetbtsblanc.DataAccess;

namespace projetbtsblanc.Controllers
{
    public class MedicamentController
    {
        private MedicamentDAO _dao = new();
        public List<Medicament> ObtenirTousLesMedicaments() => _dao.ObtenirTousLesMedicaments();
    }
}