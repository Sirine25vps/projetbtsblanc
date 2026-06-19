using System;
using System.Collections.Generic;
using projetbtsblanc.Models;

namespace projetbtsblanc.Models
{ }
    public class Ordonnance
    {
        // Les liaisons vers les autres classes (Clés étrangères en base de données)
        public Medecin Medecin { get; set; }
        public Patient Patient { get; set; }

        // La collection qui va contenir toutes les lignes de la prescription
        public List<Medicament> Medicaments { get; set; }

        public DateTime DateEmission { get; set; }

        // internal set : Sécurité empêchant la modification de l'ID depuis l'extérieur du projet (ex: depuis les fenêtres Windows Forms)
        public int Id { get; internal set; }

        //Constructeur par défaut
        public Ordonnance()
        {
            // On instancie la liste vide dès la création de l'ordonnance, si on ne fait pas ça, la liste est "NULL" et le programme plantera dès qu'on essaiera d'ajouter un médicament avec .Add()
            Medicaments = new List<Medicament>();
        }

        // Constructeur paramétré pour créer rapidement une ordonnance liée à un médecin et un patient.
        public Ordonnance(Medecin medecin, Patient patient)
        {
            Medecin = medecin;
            Patient = patient;

            // On attribue automatiquement la date et l'heure actuelles
            DateEmission = DateTime.Now;

            // On initialise la liste des médicaments
            Medicaments = new List<Medicament>();
        }

        // Méthode d'assistance (Helper) pour ajouter facilement un médicament à l'ordonnance
        public void AjouterMedicament(Medicament m)
        {
            Medicaments.Add(m);
        }
    }
