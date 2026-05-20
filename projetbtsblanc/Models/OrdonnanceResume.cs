using System;
using System.Collections.Generic;
using System.Text;

namespace projetbtsblanc.Models
{
    /// <summary>
    /// Vue simplifiée d'une ordonnance, pour affichage dans
    /// l'historique d'un patient. On parle de "DTO"
    /// (Data Transfer Object) ou de "ViewModel" : un objet
    /// conçu spécifiquement pour transporter des données
    /// vers la couche d'affichage.
    /// </summary>
    public class OrdonnanceResume
    {
        public int Id { get; set; }
        public DateTime DateEmission { get; set; }
        public string MedecinNom { get; set; }
        public string MedecinSpecialite { get; set; }
    }
}