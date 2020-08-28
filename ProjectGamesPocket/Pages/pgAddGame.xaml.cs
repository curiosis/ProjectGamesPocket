using ProjectGamesPocket.DAL.Entities;
using ProjectGamesPocket.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
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
    /// Logika interakcji dla klasy pgAddGame.xaml
    /// </summary>
    public partial class pgAddGame : Page
    {
        public pgAddGame()
        {
            InitializeComponent();
            type_combobox.ItemsSource = ListType();
            pegi_combobox.ItemsSource = ListPEGI();
            ex_combobox.ItemsSource = ListExclusive();
            isSeries_combobox.ItemsSource = ListIsSeries();

        }

        private static List<string> ListType()
        {
            List<string> listType = new List<string>();

            listType.Add(Properties.Resources.gameType1);
            listType.Add(Properties.Resources.gameType2);
            listType.Add(Properties.Resources.gameType3);
            listType.Add(Properties.Resources.gameType4);
            listType.Add(Properties.Resources.gameType5);
            listType.Add(Properties.Resources.gameType6);
            listType.Add(Properties.Resources.gameType7);
            listType.Add(Properties.Resources.gameType8);
            listType.Add(Properties.Resources.gameType9);
            listType.Add(Properties.Resources.gameType10);
            listType.Add(Properties.Resources.gameType11);
            
            return listType;
        }

        private static List<string> ListExclusive()
        {
            List<string> listExclusive = new List<string>();

            listExclusive.Add(Properties.Resources.gameEx1);
            listExclusive.Add(Properties.Resources.gameEx2);
            listExclusive.Add(Properties.Resources.gameEx3);
            listExclusive.Add(Properties.Resources.gameEx4);
            listExclusive.Add(Properties.Resources.gameEx5);
            listExclusive.Add(Properties.Resources.gameEx6);
            listExclusive.Add(Properties.Resources.gameEx7);
            listExclusive.Add(Properties.Resources.gameEx8);
            listExclusive.Add(Properties.Resources.gameEx9);
            listExclusive.Add(Properties.Resources.gameEx10);
            listExclusive.Add(Properties.Resources.gameEx11);
            listExclusive.Add(Properties.Resources.gameEx12);
            listExclusive.Add(Properties.Resources.gameEx13);
            listExclusive.Add(Properties.Resources.gameEx14);
            listExclusive.Add(Properties.Resources.gameEx15);
            listExclusive.Add(Properties.Resources.gameEx16);
            listExclusive.Add(Properties.Resources.gameEx17);
            listExclusive.Add(Properties.Resources.gameEx18);

            return listExclusive;
        }

        private static List<string> ListPEGI()
        {
            List<string> listpegi = new List<string>();
            listpegi.Add(Properties.Resources.gamePEGI1);
            listpegi.Add(Properties.Resources.gamePEGI2);
            listpegi.Add(Properties.Resources.gamePEGI3);
            listpegi.Add(Properties.Resources.gamePEGI4);
            listpegi.Add(Properties.Resources.gamePEGI5);

            
            return listpegi;
        }

        private static List<string> ListIsSeries()
        {
            List<string> listisSeries = new List<string>();
            listisSeries.Add(Properties.Resources.gameIsSeries1);
            listisSeries.Add(Properties.Resources.gameIsSeries2);
            return listisSeries;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = Name_textbox.Text;
                string publisher = publisher_textbox.Text;
                string producer = producent_textbox.Text;
                string type = type_combobox.SelectedItem.ToString();
                double price = double.Parse(price_textbox.Text);
                string date = Date();
                int metacritics = int.Parse(meta_textbox.Text);
                string exclusive = ex_combobox.Text;
                string isSeries = isSeries_combobox.Text;
                int pegi = int.Parse(pegi_combobox.Text);
                var newGame = new Games(name, publisher, producer, type, price, date, metacritics, exclusive, isSeries, pegi);
                GamesRepo.Insert(newGame);
            }
            catch
            {

            }
            
        }
        
        private string Date()
        {
            string s1 = dp1.SelectedDate.ToString();
            return (s1.Substring(6, 4)+"-"+ s1.Substring(3, 2)+"-"+s1.Substring(0, 2));
        }
    }
}
