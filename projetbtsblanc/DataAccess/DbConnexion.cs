using MySql.Data.MySqlClient;

namespace GSB.Ordonnances.DataAccess
{
    public static class DbConnexion
    {
        private const string CHAINE_CONNEXION =
        "Server=127.0.0.1;" +
        "Port=3306;" +
        "Database=gsb_ordonnances;" +
        "Uid=gsb;" +
        "Pwd=gsbpass;" +
        "AllowPublicKeyRetrieval=True;" +
        "SslMode=Preferred;";

        public static MySqlConnection Ouvrir()
        {
            MySqlConnection cnx = new MySqlConnection(CHAINE_CONNEXION);
            cnx.Open();
            return cnx;
        }
    }
}