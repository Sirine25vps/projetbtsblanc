using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projetbtsblanc.Models;
using GSB.Ordonnances.DataAccess;

namespace projetbtsblanc.DataAccess
{
    //classe DAO dédiée aux opérations sur la table MEDICAMENT 
    public class MedicamentDAO
    {

        //exécute une requête SQL pour récupérer tous les médicaments de la base de données et les retourne sous forme d'une liste d'objets Medicament
        public List<Medicament> ObtenirTousLesMedicaments()
        {
            // Création d'une liste vide pour stocker les médicaments récupérés
            List<Medicament> liste = new();

           //on sélectionne les 4 colonnes utiles
            string sql = "SELECT codeMedicament, nom, dosage, unite FROM MEDICAMENT";

            //sécurisation de la connexion à la base de données avec les blocs "using"
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            using (MySqlDataReader r = cmd.ExecuteReader())
            {

                //la boucle tourne pour lire chaque médicament, ligne par ligne
                while (r.Read())
                {

                    //instancie un nouveau médicament et on l'ajoute directement à la liste 
                    liste.Add(new Medicament(

                        //programmation défensive: on vérifie que chaque case n'est pas NULL pour empêcher le plantage de l'application. Si c'est NULL, on met un texte vide "".
                        r["codeMedicament"] != DBNull.Value ? r["codeMedicament"].ToString() : "",
                        r["nom"] != DBNull.Value ? r["nom"].ToString() : "",
                        r["dosage"] != DBNull.Value ? r["dosage"].ToString() : "",
                        r["unite"] != DBNull.Value ? r["unite"].ToString() : ""
                    ));
                }
            }
            return liste;
        }
    }
}