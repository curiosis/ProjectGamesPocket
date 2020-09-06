﻿using ProjectGamesPocket.Assets.Scripts;
using ProjectGamesPocket.DAL.Entities;
using ProjectGamesPocket.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectGamesPocket.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        Users User = null;
        public Account()
        {
            InitializeComponent();
            gamesUserListView.ItemsSource = GamesRepo.GetByLogin(Assets.Scripts.Login.UserLogin);
            SetData();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Assets.Scripts.Pesel.PESEL(check.Text))
            {
                result.Text = "CORRECT";
                Users user = new Users(Assets.Scripts.Login.UserLogin, User.Money);
                UsersRepo.Update(user,100);
                SetData();
            }
            else
            {
                result.Text = Assets.Scripts.Login.UserLogin;
            }
        }

        private void gamesUserListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void SetData()
        {
            var UserList = UsersRepo.GetAll();

            

            foreach (var user in UserList)
            {
                if (Assets.Scripts.Login.UserLogin == user.Login)
                {
                    User = new Users(user);
                    break;
                }
            }
            if (User != null)
            {
                //age = User.Age;
                actualna.Text = User.Money.ToString();


                Assets.Scripts.Login.CurrentUser = User;
            }
        }
    }
}

