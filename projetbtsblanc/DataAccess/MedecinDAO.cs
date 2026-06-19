using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projetbtsblanc.Models;
using GSB.Ordonnances.DataAccess;

namespace projetbtsblanc.DataAccess
{
    //classe DAO dédiée aux opérations sur la table MEDECIN dans la BDD 
    public class MedecinDAO
    {
        //exécute une requête SQL pour récupérer l'ensemble des médecins
        public List<Medecin> ObtenirTousLesMedecins()
        {
           
            //on prépare une liste vide qui va accueillir les médecins
            List<Medecin> liste = new();
            
            //la requête SQL sélectionne les colonnes dont on a besoin 
            string sql = "SELECT numMedecin, nom, prenom, dateNaissance, numeroRPPS, specialite FROM MEDECIN";

            // On utilise les blocs "using" pour ouvrir la connexion, envoyer la requête, et lire la réponse, cela garantit la fermeture de la connexion à la fin
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new(sql, cnx))
            using (MySqlDataReader r = cmd.ExecuteReader())
            {
                //la boucle tourne tant qu'il y a des lignes à lire dans le résultat de la requête
                while (r.Read())
                {

                    //on instancie un nouvel objet Medecin en récupérant les informations dans la ligne actuelle (r)
                    Medecin m = new Medecin(
                        r.GetString("nom"),
                        r.GetString("prenom"),
                        r.GetDateTime("dateNaissance"),
                        r.GetString("numeroRPPS"),

                        // Gestion des valeurs NULL en base de données : on vérifie si la spécialité est vide (DBNull.Value). Si oui, on met un texte vide (""). Sinon, on convertit la valeur en texte. Cela évite que l'application ne plante.
                        r["specialite"] != DBNull.Value ? r["specialite"].ToString() : ""
                    );

                    // On assigne manuellement la clé primaire (ID) de la base de données à l'objet Medecin. Cela permet de garder une trace de l'identifiant unique du médecin dans la base de données
                    m.Id = r.GetInt32("numMedecin");

                    // On ajoute ce médecin à notre liste 
                    liste.Add(m);
                }
            }

            // On renvoie la liste remplie au contrôleur qui l'a demandée
            return liste;
        }
    }
}