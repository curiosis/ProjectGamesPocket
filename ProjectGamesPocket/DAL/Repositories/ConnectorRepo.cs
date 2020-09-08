using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ProjectGamesPocket.DAL.Repositories
{
    class ConnectorRepo
    {
        private const string GET_ALL = "SELECT * FROM CONNECTOR";
        private const string INSERT = "INSERT INTO CONNECTOR (login, id_game) VALUES ";

        public static List<Entities.Connector> GetAll()
        {
            List<Entities.Connector> diet = new List<Entities.Connector>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_ALL, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    diet.Add(new Entities.Connector(reader));
                connection.Close();
            }
            return diet;
        }

        public static bool Insert(Entities.Connector connector)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{INSERT} {connector.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                condition = true;
                connector.ID = (int)command.LastInsertedId;
                connection.Close();
            }
            return condition;
        }

        public static bool Delete(string login)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"DELETE FROM CONNECTOR WHERE LOGIN='{login}'", connection);
                connection.Open();

                var n = command.ExecuteNonQuery();
                if (n == 1)
                    condition = true;

                connection.Close();
            }
            return condition;
        }
    }
}
