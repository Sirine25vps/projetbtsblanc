using System;

namespace projetbtsblanc.Models
{
    // 1. On ajoute "abstract" ici pour bloquer la création d'une Personne seule
    public abstract class Personne
    {
        // 2. On ajoute l'Id requis pour le futur mapping SQL
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }

        public Personne()
        {
        }

        public Personne(string nom, string prenom, DateTime dateNaissance)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaissance = dateNaissance;
        }

        public int CalculerAge()
        {
            int age = DateTime.Now.Year - DateNaissance.Year;

            if (DateTime.Now.Month < DateNaissance.Month || (DateTime.Now.Month == DateNaissance.Month && DateTime.Now.Day < DateNaissance.Day))
            {
                age--;
            }

            return age;
        }

        public virtual string Presentation()
        {
            return $"{Prenom} {Nom}";
        }
    }
}