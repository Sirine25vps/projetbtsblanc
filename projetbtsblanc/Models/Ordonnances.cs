using System;
using System.Collections.Generic;
using projetbtsblanc.Models;

namespace projetbtsblanc.Models
{
    public class Ordonnance
    {
        public Medecin Medecin { get; set; }
        public Patient Patient { get; set; }
        public List<Medicament> Medicaments { get; set; }
        public DateTime DateEmission { get; set; }
        public int Id { get; internal set; }

        public Ordonnance()
        {
            Medicaments = new List<Medicament>();
        }
        public Ordonnance(Medecin medecin, Patient patient)
        {
            Medecin = medecin;
            Patient = patient;
            DateEmission = DateTime.Now;
            Medicaments = new List<Medicament>();
        }

        public void AjouterMedicament(Medicament m)
        {
            Medicaments.Add(m);
        }
    }
}