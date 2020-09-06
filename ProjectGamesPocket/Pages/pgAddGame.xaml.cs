using ProjectGamesPocket.DAL.Entities;
using ProjectGamesPocket.DAL.Repositories;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace ProjectGamesPocket.Pages
{
    public partial class PgAddGame : Page
    {
        public PgAddGame()
        {
            InitializeComponent();
            type_combobox.ItemsSource = ListType();
            pegi_combobox.ItemsSource = ListPEGI();
            ex_combobox.ItemsSource = ListExclusive();
            isSeries_combobox.ItemsSource = ListIsSeries();

        }

        private static List<string> ListType()
        {
            List<string> listType = new List<string>
            {
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
                Properties.Resources.gamePEGI1,
                Properties.Resources.gamePEGI2,
                Properties.Resources.gamePEGI3,
                Properties.Resources.gamePEGI4,
                Properties.Resources.gamePEGI5
            };


            return listpegi;
        }

        private static List<string> ListIsSeries()
        {
            List<string> listisSeries = new List<string>
            {
                Properties.Resources.gameIsSeries1,
                Properties.Resources.gameIsSeries2
            };
            return listisSeries;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name;
            #region try/catch

            try
            {
                name = Name_textbox.Text;
            }
            catch
            {
                MessageBox.Show(Properties.Resources.errorAddGameChar + " 'Name'", Properties.Resources.errorError);
                goto End;
            }

            string publisher;
            try
            {
                publisher = publisher_textbox.Text;
            }
            catch
            {
                MessageBox.Show(Properties.Resources.errorAddGameChar + " 'Publisher'", Properties.Resources.errorError);
                goto End;
            }

            string producer;
            try
            {
                producer = producent_textbox.Text;
            }
            catch
            {
                MessageBox.Show(Properties.Resources.errorAddGameChar + " 'Producer'", Properties.Resources.errorError);
                goto End;
            }

            double price;
            try
            {
                price = double.Parse(price_textbox.Text);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.errorAddGameDouble + " 'Price'", Properties.Resources.errorError);
                goto End;
            }

            uint metacritics;
            try
            {
                metacritics = uint.Parse(meta_textbox.Text);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.errorAddGameInt + " 'Metacritics'", Properties.Resources.errorError);
                goto End;
            }

            uint pegi;
            try
            {
                pegi = uint.Parse(pegi_combobox.Text);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.errorAddGameInt + " 'PEGI'", Properties.Resources.errorError);
                goto End;
            }

            #endregion

            try
            {
                string date = Date();
                string exclusive = ex_combobox.Text;
                string isSeries = isSeries_combobox.Text;
                string type = type_combobox.SelectedItem.ToString();

                var newGame = new Games(name, publisher, producer, type, price, date, metacritics, exclusive, isSeries, pegi);
                GamesRepo.Insert(newGame);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.errorAddGameNewGame, Properties.Resources.errorError);
            }
        End:;
            
        }
        
        private string Date()
        {
            string s1 = dp1.SelectedDate.ToString();
            return (s1.Substring(6, 4)+"-"+ s1.Substring(3, 2)+"-"+s1.Substring(0, 2));
        }
    }
}
