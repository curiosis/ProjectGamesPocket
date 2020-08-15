using MySql.Data.MySqlClient;

namespace ProjectGamesPocket.DAL
{
    class DBConnection
    {
        private static MySqlConnectionStringBuilder mySqlConnectionStringBuilder;

        public static string UserID
        {
            get;
            private set;
        }
        private static string Password
        {
            get;
            set;
        }
        private static string Server
        {
            get;
            set;
        }
        private static string Database
        {
            get;
            set;
        }
        private static uint Port
        {
            get;
            set;
        }

        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnection();
                return instance;
            }
        }

        public MySqlConnection Connection => new MySqlConnection(mySqlConnectionStringBuilder.ToString());

        private DBConnection()
        {
            mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder
            {
                UserID = UserID,
                Password = Password,
                Server = Server,
                Database = Database,
                Port = Port,
                CharacterSet = Properties.Settings.Default.CharacterSet
            };
        }

        // log in to database
        public static void Login(string login, string password)
        {
            UserID = login;
            Password = password;
        }

        // log in to database as root
        public static void AdminLogin()
        {
            UserID = Properties.Settings.Default.User;
            Password = Properties.Settings.Default.Password;
            Server = Properties.Settings.Default.Server;
            Database = Properties.Settings.Default.Database;
            Port = Properties.Settings.Default.Port;
        }
    }
}