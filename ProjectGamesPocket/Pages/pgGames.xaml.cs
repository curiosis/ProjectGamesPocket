using ProjectGamesPocket.Assets.Scripts;
using ProjectGamesPocket.DAL.Entities;
using ProjectGamesPocket.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class pgGames : Page
    {
        string moneyValue;
        Users User = null;
        public pgGames()
        {
            InitializeComponent();
            SetData();
            gamesListView.ItemsSource = GamesRepo.GetAll();
            
            
        }

        private void btnAddGame_Click(object sender, RoutedEventArgs e)
        {
            PgAddGame pgAddGame = new PgAddGame();
            NavigationService.Navigate(pgAddGame);
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
                moneyValue = User.Money.ToString();
                txtMoney.Text = "Your money: "+ (Math.Round(Convert.ToDouble(moneyValue),2)).ToString() +"zł";


                Assets.Scripts.Login.CurrentUser = User;
            }
        }

            private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToDouble(GamePrice) <= Convert.ToDouble(moneyValue))
            {
                try
                {
                    Connector connector = new Connector(Assets.Scripts.Login.UserLogin, Convert.ToInt32(GameID));
                    ConnectorRepo.Insert(connector);
                    Users user = new Users(Assets.Scripts.Login.UserLogin, User.Money);
                    UsersRepo.Update(user, -1*Convert.ToDouble(GamePrice));
                    MessageBox.Show("Game was added to your account!");
                    SetData();
                }
                catch
                {

                }
            }

        }

        private static int? GameID = null;
        private static double? GamePrice = null;

        private void gamesListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if ((sender as ListView).SelectedItem is DAL.Entities.Games selectedGame)
                {
                    GameID = Convert.ToInt32(selectedGame.ID);
                    GamePrice = Convert.ToDouble(selectedGame.Price);
                }
            }
            catch
            {

            }
        }
    }
}
