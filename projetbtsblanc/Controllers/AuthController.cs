using GSB.Ordonnances.DataAccess;
using MySql.Data.MySqlClient;
using projetbtsblanc.DataAccess;
using System;

namespace projetbtsblanc.Controllers
{
    public class AuthController
    {
        public bool SeConnecter(string login, string password)
        {
            // requête simple pour vérifier le login/mdp 
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                string sql = "SELECT COUNT(*) FROM UTILISATEUR WHERE login = @login AND password = @password";
                MySqlCommand cmd = new(sql, cnx);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password); 

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}