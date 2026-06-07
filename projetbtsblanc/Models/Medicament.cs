using System;

namespace projetbtsblanc.Models
{
    public class Medicament
    {
        public string CodeMedicament { get; set; } 
        public string Nom { get; set; }
        public string Dosage { get; set; }
        public string Unite { get; set; }

        public Medicament(string code, string nom, string dosage, string unite)
        {
            CodeMedicament = code;
            Nom = nom;
            Dosage = dosage;
            Unite = unite;
        }
    }
}