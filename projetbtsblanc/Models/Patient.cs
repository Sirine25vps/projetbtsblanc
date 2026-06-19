using System;
using System.Collections.Generic;

namespace projetbtsblanc.Models
{
    public class Patient : Personne
    {
        // Propriétés de base spécifiques au patient
        public string NumeroSecu { get; set; }
        public string Sexe { get; set; }

        // 1. La  propriété en arrière-plan qui stocke les données médicales
        public string Pathologies { get; set; }

        // La  liste contenant les allergies séparément 
        public List<string> Allergies { get; set; }

        // 2. Propriété calculée pour l'affichage (Lecture seule)
        // Transforme la liste des allergies en un texte lisible pour le tableau de l'interface
        public string ListeAllergies
        {
            get
            {
                // S'il n'y a pas d'allergies, on renvoie un texte par défaut pour l'utilisateur
                if (Allergies == null || Allergies.Count == 0) return "Aucune";

                // string.Join prend tous les éléments de la liste et les colle ensemble en mettant ", " entre chaque.
                return string.Join(", ", Allergies);
            }
        }

        //On passe les infos générales au constructeur parent avec ": base"
        public Patient(string nom, string prenom, DateTime dateNaissance, string numeroSecu)
            : base(nom, prenom, dateNaissance)
        {
            NumeroSecu = numeroSecu;
            // On initialise la liste vide pour éviter les crashs si on essaie de lire les allergies avant d'en avoir ajouté
            Allergies = new List<string>();
        }

        // Constructeur par défaut
        public Patient() : base()
        {
            Allergies = new List<string>();
        }

        // Méthode utilisant la classe mère pour vérifier la majorité
        // Le symbole "=>" est un raccourci propre qui remplace le bloc { return ...; }
        public bool EstMajeur() => CalculerAge() >= 18;

        //polymorphisme : On redéfinit la présentation par défaut de la classe Personne
        public override string Presentation() => $"{Prenom} {Nom}";

        //Utile pour les listes déroulantes (ComboBox) pour qu'elles affichent "Prénom Nom" au lieu du nom technique de l'objet.
        public override string ToString()
        {
            return $"{Prenom} {Nom}";
        }
    }
}