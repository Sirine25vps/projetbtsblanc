using MySql.Data.MySqlClient;

namespace GSB.Ordonnances.DataAccess
{
    //Classe qui centralise et gère la connexion à la base de données MySQL
    public static class DbConnexion
    {
        // La chaîne de connexion contient tous les paramètres nécessaires pour trouver et ouvrir la base de données.
        // Server = L'adresse de la base signifie que la base est sur la même machine que l'application
        private const string CHAINE_CONNEXION =
        "Server=127.0.0.1;" +
        "Port=3306;" +
        "Database=gsb_ordonnances;" +
        "Uid=gsb;" +
        "Pwd=gsbpass;" +
        "AllowPublicKeyRetrieval=True;" +
        "SslMode=Preferred;" +
        "CharSet=utf8mb4;"; // L'ajout indispensable pour régler le bug des accents entre C# et MySQL


        // Crée et ouvre une nouvelle connexion à la BDD
        //L'objet MySqlConnection est prêt à être utilisé par les requêtes SQL.</returns>
        public static MySqlConnection Ouvrir()
        {
            //on prépare la connexion à la base de données avec la chaîne de connexion en lui donnant les informations nécessaires pour se connecter à la base de données MySQL
            MySqlConnection cnx = new MySqlConnection(CHAINE_CONNEXION);
            //on ouvre la porte vers la BDD
            cnx.Open();
            //on renvoie la connexion ouverte pour que les autres fichiers puissent l'utiliser
            return cnx;
        }
    }
}