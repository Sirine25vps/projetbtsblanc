using System;
using System.Collections.Generic;
using System.Text;

namespace projetbtsblanc.Models
{
    // Modèle spécifique créé pour l'affichage (DataBinding)
    // Représente une ligne précise du tableau des prescriptions d'une ordonnance
    public class LignePrescription
    {
        // On utilise des types simples (string et int) pour que le datagridview s'affiche correctement, il lit très facilement ces propriétés pour générer les colonnes
        public string NomMedicament { get; set; }
        public string Posologie { get; set; }
        public int DureeJours { get; set; }

        //constructeur pour initialiser rapidement une ligne de prescription prête à être affichée
        public LignePrescription(string nomMedicament, string posologie, int dureeJours)
        {
            NomMedicament = nomMedicament;
            Posologie = posologie;
            DureeJours = dureeJours;
        }

        //retourne une phrase formatée résumant la prescription. Très utile pour du débogage (Console.Writeline) ou pour exporter l'ordonnance en texte/PDF plus tard 
        public string Afficher()
        {
            //le symbole $ devant les guillemets s'appelle l'interpolation de chaines, ça permet d'insérer directement des variables entre accolades sans utiliser plein de "+". 
            return $"Médicament : {NomMedicament} : {Posologie} pendant {DureeJours} jours.";
        }
    }
}