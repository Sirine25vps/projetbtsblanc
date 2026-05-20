using System;

namespace projetbtsblanc.Models
{
    public class Personne
    {
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
             if (DateTime.Now.DayOfYear < DateNaissance.DayOfYear) age--; 
             return age; 
        }

         public virtual string Presentation() 
        {
            return $"{Prenom} {Nom}"; 
    }
}
}