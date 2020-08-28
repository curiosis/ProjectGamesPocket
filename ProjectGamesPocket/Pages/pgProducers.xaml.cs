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
            string name = name_search.Text;
            string country = country_search.Text;
            string yoe = yoe_search.Text;

            producersListView.ItemsSource = ProducersRepo.Getby(name,country,yoe);
        }
        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            string name="", country="", website="";
            int yoe=0;
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
