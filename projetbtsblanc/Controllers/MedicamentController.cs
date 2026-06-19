using projetbtsblanc.DataAccess;
using projetbtsblanc.Models;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace projetbtsblanc.Controllers
{
    public class MedicamentController
    {
        //Fait le pont entre l'interface visuelle et la base de données pour la gestion des médicaments
        private MedicamentDAO _dao = new();

        //demande au DAO de récupérer la liste complète des médicaments 
        // le symbole => est un raccourci d'écriture qui remplace les accolades et le mot "return"  
        public List<Medicament> ObtenirTousLesMedicaments() => _dao.ObtenirTousLesMedicaments();
    }
}