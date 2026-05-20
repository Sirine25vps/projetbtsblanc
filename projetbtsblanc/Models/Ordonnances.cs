using System;
using System.Collections.Generic;
using System.Text;

namespace projetbtsblanc.Models
{ 
    public class Ordonnance
        {
            public Medecin Prescripteur { get; set; } 
            public Patient Patient { get; set; } 
            public List<Prescription> LesPrescriptions { get; set; }
            public DateTime DateEmission { get; set; }

            public Ordonnance(Medecin medecin, Patient patient)
            {
                Prescripteur = medecin;
                Patient = patient;
                DateEmission = DateTime.Now; 
                LesPrescriptions = new List<Prescription>();
            }

            public void AjouterPrescription(Prescription p)
            {
                LesPrescriptions.Add(p);
            }
        }
    }