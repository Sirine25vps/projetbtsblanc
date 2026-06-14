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
        "SslMode=Preferred;" +
        "CharSet=utf8mb4;"; // L'ajout indispensable pour régler le bug des accents

        public static MySqlConnection Ouvrir()
        {
            MySqlConnection cnx = new MySqlConnection(CHAINE_CONNEXION);
            cnx.Open();
            return cnx;
        }
    }
}