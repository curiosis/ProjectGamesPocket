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
        uint age;

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

            Users User = null;

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
                txtMoney.Text = "Your money: "+ User.Money.ToString() +"zł";


                Assets.Scripts.Login.CurrentUser = User;
            }
        }

            private void Button_Click(object sender, RoutedEventArgs e)
        {
            Connector connector = new Connector(Assets.Scripts.Login.UserLogin, int.Parse(index.Text));
            ConnectorRepo.Insert(connector);
            MessageBox.Show("Game was added to your account!");
        }

        private static int? GameID = null;

        private void gamesListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if ((sender as ListView).SelectedItem is DAL.Entities.Games selectedGame)
                {
                    GameID = Convert.ToInt32(selectedGame.Name);
                    kasa.Text = GameID.ToString();
                }
            }
            catch
            {

            }
        }
    }
}
