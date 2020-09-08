using MySql.Data.MySqlClient;
using ProjectGamesPocket.DAL.Entities;
using System.Collections.Generic;

namespace ProjectGamesPocket.DAL.Repositories
{
    class ProducersRepo
    {
        private const string GET_ALL = "SELECT * FROM producers";
        private const string INSERT = "INSERT INTO Producers(NameProducer, YoE, Country, Website) VALUES";

        public static List<Entities.Producers> GetAll()
        {
            List<Entities.Producers> producers = new List<Entities.Producers>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"{GET_ALL}", connection);
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

    

    public static List<Entities.Producers> Getby(string name, string country, string yoe)
        {
            List<Entities.Producers> producers = new List<Entities.Producers>();

            using (var connection = DBConnection.Instance.Connection)
            {

                string commandSearch = $"SELECT* FROM producers WHERE(nameProducer LIKE '%{name}%' OR nameProducer LIKE '%{name}' OR nameProducer LIKE '{name}%') AND(Country LIKE '%{country}%' OR Country LIKE '%{country}' OR Country LIKE '{country}%')";
                
                if(yoe != "")
                {
                    commandSearch += $" AND yoe='{yoe}'";
                }

                MySqlCommand mySqlCommand = new MySqlCommand($"{commandSearch}", connection);
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
