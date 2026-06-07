using System;
using System.Collections.Generic;

namespace projetbtsblanc.Models
{
    // Patient hérite de la classe Personne
    public class Patient : Personne
    {
     
        public string NumeroSecu { get; set; }
        public List<string> Allergies { get; set; }
        public double Poids { get; set; }
        public double Taille { get; set; }
        public string Sexe { get; set; }
        public string Pathologies { get; set; }
       
       
        public Patient(string nom, string prenom, DateTime dateNaissance, string numeroSecu)
            : base(nom, prenom, dateNaissance)
        {
            NumeroSecu = numeroSecu;
            Allergies = new List<string>();
        }

        public Patient() : base()
        {
            Allergies = new List<string>();
        }

        public bool EstMajeur()
        {
            return CalculerAge() >= 18;
        }
 
        public override string Presentation()
        {
            return $"{Prenom} {Nom}";
        }
    }
}