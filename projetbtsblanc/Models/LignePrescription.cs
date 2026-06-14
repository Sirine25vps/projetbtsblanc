using System;
using System.Collections.Generic;
using System.Text;

namespace projetbtsblanc.Models
{
    // On renomme la classe pour correspondre au DAO
    public class LignePrescription
    {
        // On utilise des string simples pour que le tableau s'affiche correctement
        public string NomMedicament { get; set; }
        public string Posologie { get; set; }
        public int DureeJours { get; set; }

        public LignePrescription(string nomMedicament, string posologie, int dureeJours)
        {
            NomMedicament = nomMedicament;
            Posologie = posologie;
            DureeJours = dureeJours;
        }

        public string Afficher()
        {
            return $"Médicament : {NomMedicament} : {Posologie} pendant {DureeJours} jours.";
        }
    }
}