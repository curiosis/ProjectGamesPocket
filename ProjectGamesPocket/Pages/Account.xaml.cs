using ProjectGamesPocket.DAL.Entities;
using ProjectGamesPocket.DAL.Repositories;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectGamesPocket.Pages
{

    public partial class Account : Page
    {
        Users User = null;
        string moneyValue;

        public Account()
        {
            InitializeComponent();
            gamesUserListView.ItemsSource = GamesRepo.GetByLogin(Assets.Scripts.Login.UserLogin);
            SetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Assets.Scripts.Pesel.PESEL(check.Text))
            {
                Users user = new Users(Assets.Scripts.Login.UserLogin, User.Money);
                UsersRepo.Update(user,100);
                check.Text = "";
                SetData();
            }
        }


        private void GamesUserListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                userName.Content = "Hello "+User.Login+"!";
                moneyValue = User.Money.ToString();
                actualna.Text = (Math.Round(Convert.ToDouble(moneyValue), 2)).ToString();

                Assets.Scripts.Login.CurrentUser = User;
            }
        }
    }
}

