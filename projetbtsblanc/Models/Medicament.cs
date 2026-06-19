using System;

namespace projetbtsblanc.Models
{
    
    public class Medicament
    {
        // On utilise un string pour le code afin de conserver les éventuels zéros de début ou les lettres
        public string CodeMedicament { get; set; }
        public string Nom { get; set; }
        public string Dosage { get; set; }
        public string Unite { get; set; }

        // Constructeur principal pour instancier un médicament avec toutes ses caractéristiques
        public Medicament(string code, string nom, string dosage, string unite)
        {
            CodeMedicament = code;
            Nom = nom;
            Dosage = dosage;
            Unite = unite;
        }
    }
}