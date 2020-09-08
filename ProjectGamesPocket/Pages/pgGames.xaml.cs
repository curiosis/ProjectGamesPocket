using ProjectGamesPocket.DAL.Entities;
using ProjectGamesPocket.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace ProjectGamesPocket.Pages
{
    public partial class PgGames : Page
    {
        string moneyValue;
        Users User = null;
        public PgGames()
        {
            InitializeComponent();
            type_combobox.ItemsSource = ListType();
            pegi_combobox.ItemsSource = ListPEGI();
            exclusive_combobox.ItemsSource = ListExclusive();
            SetData();
            gamesListView.ItemsSource = GamesRepo.GetAll();
            
        }

        private void BtnAddGame_Click(object sender, RoutedEventArgs e)
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

        private void GamesListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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

        private static List<string> ListType()
        {
            List<string> listType = new List<string>
            {
                "",
                Properties.Resources.gameType1,
                Properties.Resources.gameType2,
                Properties.Resources.gameType3,
                Properties.Resources.gameType4,
                Properties.Resources.gameType5,
                Properties.Resources.gameType6,
                Properties.Resources.gameType7,
                Properties.Resources.gameType8,
                Properties.Resources.gameType9,
                Properties.Resources.gameType10,
                Properties.Resources.gameType11
                
            };

            return listType;
        }

        private static List<string> ListExclusive()
        {
            List<string> listExclusive = new List<string>
            {
                "",
                Properties.Resources.gameEx1,
                Properties.Resources.gameEx2,
                Properties.Resources.gameEx3,
                Properties.Resources.gameEx4,
                Properties.Resources.gameEx5,
                Properties.Resources.gameEx6,
                Properties.Resources.gameEx7,
                Properties.Resources.gameEx8,
                Properties.Resources.gameEx9,
                Properties.Resources.gameEx10,
                Properties.Resources.gameEx11,
                Properties.Resources.gameEx12,
                Properties.Resources.gameEx13,
                Properties.Resources.gameEx14,
                Properties.Resources.gameEx15,
                Properties.Resources.gameEx16,
                Properties.Resources.gameEx17,
                Properties.Resources.gameEx18
                
            };

            return listExclusive;
        }

        private static List<string> ListPEGI()
        {
            List<string> listpegi = new List<string>
            {
                "",
                Properties.Resources.gamePEGI1,
                Properties.Resources.gamePEGI2,
                Properties.Resources.gamePEGI3,
                Properties.Resources.gamePEGI4,
                Properties.Resources.gamePEGI5
            };


            return listpegi;
        }

        private void BtnSearchGame_Click(object sender, RoutedEventArgs e)
        {
            string name = nameSearch.Text;
            string publisher = publisherSearch.Text;
            string producer = producerSearch.Text;
            string type = type_combobox.Text;
            string exc = exclusive_combobox.Text;
            string pegi = pegi_combobox.Text;

            gamesListView.ItemsSource = GamesRepo.Getby(name, publisher, producer, type, exc, pegi);
        }
    }
}
