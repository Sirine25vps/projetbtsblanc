using System;
using System.Collections.Generic;
using System.Text;

namespace projetbtsblanc.Models
{

    public class Allergie
    {

        // Propriétés de la classe Allergie avec leurs droits de lecture (get) et d'écriture (set)
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        // Constructeur vide, très utile pour certains outils ou listes qui ont besoin de créer une allergie vierge avant de la remplir
        public Allergie()
        {
        }

        // Constructeur principal pour créer une allergie et la remplir directement en une seule ligne de code
       // la description = "" est un paramètre optionnel, si on crée une allergie sans lui donner de description C# mettra automatiquement un texte vide au lieu de faire planter le programme avec un NULL
        public Allergie(int id, string nom, string description = "")
        {
            Id = id;
            Nom = nom;
            Description = description;
        }
    }
}