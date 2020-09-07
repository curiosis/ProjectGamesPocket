using MySql.Data.MySqlClient;
using ProjectGamesPocket.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjectGamesPocket.DAL.Repositories
{
    class GamesRepo
    {

        public static string ADD_OPT = "WHERE ID = ";
        private const string GET_ALL = "SELECT id_game, namegame, publisher, producer, type,price,release_date,metacritics,exclusive,isSeries,pegi FROM games";
        private const string INSERT = "INSERT INTO Games (namegame,publisher,producer,type,price,release_date,metacritics,exclusive,isSeries,pegi) VALUES";

        public static List<Entities.Games> GetAll()
        {
            List<Entities.Games> games = new List<Entities.Games>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand mySqlCommand = new MySqlCommand(GET_ALL, connection);
                connection.Open();
                var reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    games.Add(new Entities.Games(reader));
                }
                connection.Close();
            }
            return games;
        }

        public static List<Entities.Games> GetByLogin(string login)
        {
            List<Entities.Games> games = new List<Entities.Games>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"SELECT G.* " +
                    $"FROM GAMES G, CONNECTOR C " +
                    $"WHERE C.LOGIN = '{login}' AND C.ID_GAME = G.ID_GAME", connection);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    games.Add(new Entities.Games(reader));
                connection.Close();
            }
            return games;
        }

        public static List<Entities.Games> Getby(string name, string publisher, string producer, string type, string exc, string pegi)
        {
            List<Entities.Games> games = new List<Entities.Games>();

            using (var connection = DBConnection.Instance.Connection)
            {

                string commandSearch = $"SELECT* FROM games WHERE(namegame LIKE '%{name}%' OR namegame LIKE '%{name}' OR namegame LIKE '{name}%') AND" +
                    $"(Publisher LIKE '%{publisher}%' OR Publisher LIKE '%{publisher}' OR Publisher LIKE '{publisher}%') AND" +
                    $"(Producer LIKE '%{producer}%' OR Producer LIKE '%{producer}' OR Producer LIKE '{producer}%')";

                if (type != "")
                    commandSearch += $"AND (Type LIKE '{type}')";

                if (exc != "")
                    commandSearch += $"AND (Exclusive LIKE '{exc}')";

                if (pegi != "")
                    commandSearch += $"AND (PEGI LIKE '{pegi}')";


                MySqlCommand mySqlCommand = new MySqlCommand($"{commandSearch}", connection);
                connection.Open();
                var reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    games.Add(new Entities.Games(reader));
                }
                connection.Close();
            }
            return games;
        }

        public static bool Insert(Games games)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"{INSERT} {games.ToInsert()}", connection);
                MessageBox.Show(INSERT, games.ToInsert());
                connection.Open();
                var id = mySqlCommand.ExecuteNonQuery();
                condition = true;
                games.ID = (int)mySqlCommand.LastInsertedId;
                connection.Close();
            }
            return condition;
        }
    }
}
