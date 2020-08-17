using MySql.Data.MySqlClient;
using ProjectGamesPocket.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGamesPocket.DAL.Repositories
{
    class ProducersRepo
    {
        public static string ADD_OPT = "WHERE ID = ";
        private const string GET_ALL = "SELECT * FROM producers";
        private const string INSERT = "INSERT INTO Producers VALUE";

        public static List<Entities.Producers> GetAll()
        {
            List<Entities.Producers> producers = new List<Entities.Producers>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand mySqlCommand = new MySqlCommand(GET_ALL, connection);
                connection.Open();
                var reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    producers.Add(new Entities.Producers(reader));
                }
                connection.Close();
            }
            return producers;
        }

        public static bool Insert(Producers producers)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"{INSERT} {producers.ToInsert()}", connection);
                connection.Open();
                var id = mySqlCommand.ExecuteNonQuery();
                condition = true;
                producers.ID = (int)mySqlCommand.LastInsertedId;
                connection.Close();
            }
            return condition;
        }
    }
}
