using System;
using System.Collections.Generic;
using System.Text;

namespace projetbtsblanc.Models
{
    public class Prescription
    {
        public Medicament Medicament { get; set; }
        public string Posologie { get; set; }
        public int DureeJours { get; set; }

        public Prescription(Medicament medicament, string posologie, int dureeJours)
        {
            Medicament = medicament;
            Posologie = posologie;
            DureeJours = dureeJours;
        }
        public string Afficher()
        {
            return $"Médicament : {Medicament.Nom} {Medicament.Dosage}{Medicament.Unite} : {Posologie} pendant {DureeJours} jours.";
        }

    }
}