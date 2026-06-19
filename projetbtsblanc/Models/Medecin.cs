using System;

namespace projetbtsblanc.Models
{
    // "personne" indique que Medecin hérite de tous les attributs de la classe Personne
    public class Medecin : Personne
    {
        // On ne garde que les propriétés uniques au Médecin
        public string NumeroRPPS { get; set; }
        public string Specialite { get; set; }

        // Le constructeur complet transmet les infos communes à la classe mère via ": base(...)"
        public Medecin(string nom, string prenom, DateTime dateNaissance, string numeroRPPS, string specialite)
            : base(nom, prenom, dateNaissance)
        {
            NumeroRPPS = numeroRPPS;
            Specialite = specialite;
        }

        // Le constructeur sans paramètres appelle aussi celui de la classe mère
        public Medecin() : base()
        {
        }

        // polymorphisme : écrase (override) la méthode de présentation du parent
        // Cela renvoie une chaine de caractère adaptée au statut du médecin : "Dr NOM, Spécialité"
        public override string Presentation()
        {
            return $"Dr {Nom}, {Specialite}";
        }

        //polymorphisme : on écrase la méthode ToString par défaut de C#
        // très utile pour que les listes déroulantes (combobox) affichent directement Dr.Nom plutôt que le nom technique de l'objet
        public override string ToString()
        {
            return $"Dr. {Nom}"; 
        }
    }
}