﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using ProjectGamesPocket.DAL.Entities;
using ProjectGamesPocket.DAL.Repositories;

namespace ProjectGamesPocket.Assets.Scripts
{
    class Login
    {
        public static readonly int minLoginLength = 5;
        public static readonly int maxLoginLength = 15;
        public static readonly int minPasswordLength = 6;
        public static readonly int maxPasswordLength = 16;

        public static bool loginStatus = false;

        //public static Users currentUser;

        private static string login = "";
        public static string userLogin
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }

        public static bool CheckPasswords(string s1, string s2)
        {
            if (s2 == "" && s1 != "")
            {
                MessageBox.Show(Properties.Resources.login,
                    Properties.Resources.login);
            }
            else
            {
                if (s1 != s2)
                {
                    MessageBox.Show(Properties.Resources.login,
                        Properties.Resources.login);
                }
            }
            return s1 == s2;
        }

        public static bool HasCorrectChars(string s)
        {
            var result = s.Any(char.IsUpper) &&
                         s.Any(char.IsLower) &&
                         s.Any(char.IsDigit);

            if (result == false)
            {
                MessageBox.Show(Properties.Resources.login,
                    Properties.Resources.login);
                return false;
            }
            return true;
        }

        public static bool IsCorrectLong(string s)
        {
            var result = s.Length >= minPasswordLength &&
                         s.Length <= maxPasswordLength;

            if (!result)
            {
                MessageBox.Show(Properties.Resources.login,
                    Properties.Resources.login);
                return false;
            }

            return true;
        }

        public static bool IsPasswordCorrect(string s1, string s2)
            => CheckPasswords(s1, s2) && HasCorrectChars(s1) && IsCorrectLong(s1);

        public static bool IsCorrectLogin(string login)
        {
            var result = login.Length >= minLoginLength &&
                         login.Length <= maxLoginLength;

            if (!result)
            {
                MessageBox.Show(Properties.Resources.login,
                    Properties.Resources.login);
                return false;
            }
            return true;
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "");
            }
        }
    }
}