using System;

namespace projetbtsblanc.Models
{
   
    public abstract class Personne
    {
        // Propriétés communes
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }

        //Constructeur par défaut
        public Personne()
        {
        }

        //Constructeur principal initialisant les données de base
        public Personne(string nom, string prenom, DateTime dateNaissance)
        {
            // Le mot-clé "this" précise qu'on affecte la valeur du paramètre "nom" à la propriété "Nom" de la classe actuelle
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaissance = dateNaissance;
        }

        // Calcule l'âge exact de la personne à partir de sa date de naissance et de la date du jour
        public int CalculerAge()
        {
            // On fait d'abord une simple soustraction des années
            int age = DateTime.Now.Year - DateNaissance.Year;

            // On vérifie ensuite si l'anniversaire n'est pas encore passé cette année
            // Si le mois actuel est inférieur au mois de naissance, OU si c'est le bon mois mais que le jour n'est pas encore passé, alors on retire 1 an à l'âge
            if (DateTime.Now.Month < DateNaissance.Month || (DateTime.Now.Month == DateNaissance.Month && DateTime.Now.Day < DateNaissance.Day))
            {
                age--;
            }

            return age;
        }

        //  Renvoie une présentation par défaut de la personne
        // Le mot-clé "virtual" permet aux classes enfants (comme Medecin) d'écraser cette méthode pour la personnaliser
        public virtual string Presentation()
        {
            return $"{Prenom} {Nom}";
        }
    }
}