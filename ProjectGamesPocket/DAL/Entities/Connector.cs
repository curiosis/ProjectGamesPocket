using MySql.Data.MySqlClient;

namespace ProjectGamesPocket.DAL.Entities
{
    class Connector
    {
        public int ID { 
            get; 
            set; 
        }
        public string Login { 
            get; 
            private set; 
        }
        public int ID_Game { 
            get; 
            private set; 
        }

        public Connector(MySqlDataReader mySqlDataReader)
        {
            ID = int.Parse(mySqlDataReader["id"].ToString());
            Login = mySqlDataReader["login"].ToString();
            ID_Game = int.Parse(mySqlDataReader["id_game"].ToString());
        }

        public Connector(string login, int id_game)
        {
            Login = login;
            ID_Game = id_game;
        }

        public Connector(Connector connector)
        {
            ID = connector.ID;
            Login = connector.Login;
            ID_Game = connector.ID_Game;
        }

        public string ToInsert()
        {
            return $"('{Login}','{ID_Game}')";
        }
    }
}
