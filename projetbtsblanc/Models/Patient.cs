using System;
using System.Collections.Generic;

namespace projetbtsblanc.Models
{
    public class Patient : Personne
    {
        public string NumeroSecu { get; set; }
        public List<string> Allergies { get; set; }
        public string Sexe { get; set; }

        // 1. la propriété pour la base de données (écrivable)
        public string Pathologies { get; set; }

        // 2. Une propriété pour l'affichage dans le tableau (lecture seule)
        public string ListeAllergies
        {
            get
            {
                if (Allergies == null || Allergies.Count == 0) return "Aucune";
                return string.Join(", ", Allergies);
            }
        }

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

        public bool EstMajeur() => CalculerAge() >= 18;
        public override string Presentation() => $"{Prenom} {Nom}";

        public override string ToString()
        {
            return $"{Prenom} {Nom}";
        }
    }
}