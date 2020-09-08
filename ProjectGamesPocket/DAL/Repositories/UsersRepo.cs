using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ProjectGamesPocket.DAL.Repositories
{
    class UsersRepo
    {
        private const string GET_ALL = "SELECT * FROM users";
        public static List<Entities.Users> GetAll()
        {
            List<Entities.Users> users = new List<Entities.Users>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand mySqlCommand = new MySqlCommand(GET_ALL, connection);
                connection.Open();
                var reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                    users.Add(new Entities.Users(reader));
                connection.Close();
            }
            return users;
        }

        public static bool CreateUser(string Login, string Password)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                var command_CreateUser = new MySqlCommand($"CREATE USER '{Login}'@'localhost' IDENTIFIED BY '{Password}'", connection);
                var command_GrantContains = new MySqlCommand($"GRANT SELECT ON CONNECTOR TO '{Login}'", connection);
                var command_GrantGames = new MySqlCommand($"GRANT SELECT ON games TO '{Login}'", connection);
                var command_GrantProducers = new MySqlCommand($"GRANT SELECT ON producers TO '{Login}'", connection);
                var command_AddUser = new MySqlCommand($"INSERT INTO USERS (LOGIN, PASSWORD, MONEY) VALUES ('{Login}', '{Password}',0)", connection);

                connection.Open();
                command_CreateUser.ExecuteNonQuery();
                command_GrantContains.ExecuteNonQuery();
                command_GrantGames.ExecuteNonQuery();
                command_GrantProducers.ExecuteNonQuery();
                command_AddUser.ExecuteNonQuery();
                condition = true;
                connection.Close();
            }
            return condition;
        }

        public static bool Update(Entities.Users user,double addMoney)
        {
            bool condition = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                var money = Convert.ToDouble(user.Money.ToString());
                double sum = money + addMoney;
                string strdub = sum.ToString().Replace(',', '.');

                var command_AddUser = new MySqlCommand($"UPDATE USERS SET " +
                    $"MONEY={strdub} WHERE LOGIN='{user.Login}'", connection);

                connection.Open();
                command_AddUser.ExecuteNonQuery();
                condition = true;
                connection.Close();
            }
            return condition;
        }
    }
}
