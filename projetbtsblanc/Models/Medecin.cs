using System;

namespace projetbtsblanc.Models
{
    // "personne" indique que Medecin hérite de la classe Personne
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

        // On redéfinit la présentation spécifiquement pour le médecin
        // Cela renvoie "Dr NOM, Spécialité"
        public override string Presentation()
        {
            return $"Dr {Nom}, {Specialite}";
        }
    }
}