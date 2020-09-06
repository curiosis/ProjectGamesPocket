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
            Money = double.Parse(mySqlDataReader["money"].ToString());
            Password = mySqlDataReader["password"].ToString();
        }

        public Users(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public Users(string login, double money)
        {
            Login = login;
            Money = money;
        }

        public Users(Users user)
        {
            Login = user.Login;
            Money = user.Money;
            Password = user.Password;
        }

        public override string ToString()
        {
            return $"{Login},{Money},{Password}";
        }
    }
}
