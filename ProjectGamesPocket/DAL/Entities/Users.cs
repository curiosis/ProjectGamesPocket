using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGamesPocket.DAL.Entities
{
    class Users
    {
        public string Login
        {
            get;
            private set;
        }
        public uint Age
        {
            get;
            private set;
        }
        public double Money
        {
            get;
            private set;
        }
        public string Password
        {
            get;
            private set;
        }

        public Users(MySqlDataReader mySqlDataReader)
        {
            Login = mySqlDataReader["login"].ToString();
            Age = uint.Parse(mySqlDataReader["age"].ToString());
            Money = double.Parse(mySqlDataReader["money"].ToString());
            Password = mySqlDataReader["password"].ToString();
        }

        public Users(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public Users(string login, uint age, double money)
        {
            Login = login;
            Age = age;
            Money = money;
        }

        public Users(Users user)
        {
            Login = user.Login;
            Age = user.Age;
            Money = user.Money;
            Password = user.Password;
        }

        public override string ToString()
        {
            return $"{Login},{Age},{Money},{Password}";
        }
    }
}
