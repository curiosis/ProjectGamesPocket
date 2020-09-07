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

        private void btnInfoType_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.infoType, Properties.Resources.info);
        }

        private void btnInfoPrice_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.infoPrice, Properties.Resources.info);
        }

        private void btnInfoDate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.infoDate, Properties.Resources.info);
        }

        private void btnInfoMetacritics_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Metacritic is a website that aggregates reviews of films, TV shows, music albums, video games and formerly, books. For each product, the scores from each review are averaged.\n\nScore index\n\n\nUniversal acclaim 90–100\nGenerally favorable reviews 75–89\nMixed or average reviews 50–74\nGenerally unfavorable reviews 20–49\nOverwhelming dislike 0-19", Properties.Resources.info);
        }

        private void btnInfoExclusive_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.infoExc, Properties.Resources.info);
        }

        private void btnInfoIsSeries_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.infoIsSeries, Properties.Resources.info);
        }

        private void btnInfoPEGI_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pan European Game Information(PEGI) is a European video game content rating system established to help European consumers make informed decisions when buying video games or apps through the use of age recommendations and content descriptors.\n\n - 3 -\nThe content of games with a PEGI 3 rating is considered suitable for all age groups.The game should not contain any sounds or pictures that are likely to frighten young children.A very mild form of violence(in a comical context or a childlike setting) is acceptable.No bad language should be heard.\n\n - 7 -\nGame content with scenes or sounds that can possibly be frightening to younger children should fall in this category.Very mild forms of violence(implied, non - detailed, or non - realistic violence) are acceptable for a game with a PEGI 7 rating.\n\n - 12 -\nVideo games that show violence of a slightly more graphic nature towards fantasy characters or non - realistic violence towards human - like characters would fall in this age category.Sexual innuendo or sexual posturing can be present, while any bad language in this category must be mild. Gambling as it is normally carried out in real life in casinos or gambling halls can also be present(e.g.card games that in real life would be played for money).\n\n - 16 -\nThis rating is applied once the depiction of violence(or sexual activity) reaches a stage that looks the same as would be expected in real life. The use of bad language in games with a PEGI 16 rating can be more extreme, while games of chance, and the use of tobacco, alcohol, or illegal drugs can also be present.\n\n - 18 -\nThe adult classification is applied when the level of violence reaches a stage where it becomes a depiction of gross violence, apparently motiveless killing, or violence towards defenseless characters.The glamorization of the use of illegal drugs, and explicit sexual activity should also fall into this age category."
, Properties.Resources.info);
        }
    }
}
