using System;
    
namespace projetbtsblanc.Models

{
    public class Patient
    {
        // À AJOUTER : identifiant venant de la base
        public int Id { get; set; }
        // Propriétés existantes du cours POO
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string NumeroSecu { get; set; }
        public List<string> Allergies { get; set; }
        // Constructeur existant
        public Patient(string nom, string prenom,
        DateTime dateNaissance, string numeroSecu)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            NumeroSecu = numeroSecu;
            Allergies = new List<string>();
        }
        // À AJOUTER : constructeur sans paramètres
        // (pratique pour le binding et pour les futurs tests)
        public Patient()
        {
            Allergies = new List<string>();
        }
        public int CalculerAge()
        {
            // On calcule la différence entre l'année actuelle et l'année de naissance
            int age = DateTime.Now.Year - DateNaissance.Year;

            // Si le patient n'a pas encore fêté son anniversaire cette année, on enlève 1 an
            if (DateTime.Now.DayOfYear < DateNaissance.DayOfYear)
            {
                age--;
            }

            return age; 
        }
    }
}