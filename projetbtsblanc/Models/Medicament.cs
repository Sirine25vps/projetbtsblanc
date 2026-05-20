using System;
using System.Collections.Generic;
using System.Text;

namespace projetbtsblanc.Models
{
    public class Medicament
        {
            public string Nom { get; set; }
            public string Dosage { get; set; }
            public string Unite { get; set; }

            public Medicament(string nom, string dosage)
            {
            Nom = nom;
            Dosage = dosage;
            Unite = Unite;
            }
        }
    }