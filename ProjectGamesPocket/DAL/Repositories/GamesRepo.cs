using MySql.Data.MySqlClient;
using ProjectGamesPocket.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGamesPocket.DAL.Repositories
{
    class GamesRepo
    {
        public static string ADD_OPT = "WHERE ID = ";
        private const string GET_ALL = "SELECT id_game, namegame, publisher, producer, type,price,release_date,metacritics,exclusive,isSeries,pegi FROM games";
        private const string INSERT = "INSERT INTO Games VALUE";

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

        public static bool Insert(Games games)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"{INSERT} {games.ToInsert()}", connection);
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
