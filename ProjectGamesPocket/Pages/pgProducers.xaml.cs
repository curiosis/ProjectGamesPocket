using ProjectGamesPocket.DAL.Repositories;
using ProjectGamesPocket.DAL.Entities;
using System;
using System.Windows;
using System.Windows.Controls;


namespace ProjectGamesPocket.Pages
{
    public partial class pgProducers : Page
    {

        public pgProducers()
        {
            InitializeComponent();
            producersListView.ItemsSource = ProducersRepo.GetAll();
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            producersListView.ItemsSource = ProducersRepo.Getby(name_search.Text, country_search.Text, int.Parse(yoe_search.Text));
        }
        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            string name="", country="a", website="b";
            int yoe=1110;
            try
            {
               name = name_insert.Text;
                country = country_insert.Text;
                website = website_insert.Text;
                yoe = Convert.ToInt32(yoe_insert.Text);
                var newProducer = new Producers(name, yoe, country, website);

                ProducersRepo.Insert(newProducer);
                producersListView.ItemsSource = ProducersRepo.GetAll();
                producersListView.Items.Refresh();
            }
            catch
            {
                MessageBox.Show(name, website);
            }
        }
    }
}
