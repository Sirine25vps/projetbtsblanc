using System;
using System.Collections.Generic;
using System.Text;

namespace projetbtsblanc.Models
{
    public class Allergie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        // Constructeur vide 
        public Allergie()
        {
        }

        // Constructeur avec paramètres
        public Allergie(int id, string nom, string description = "")
        {
            Id = id;
            Nom = nom;
            Description = description;
        }
    }
}