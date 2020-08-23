using ProjectGamesPocket.DAL.Repositories;
using ProjectGamesPocket.DAL.Entities;
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
    public partial class pgProducers : Page
    {
        private string empty = "";

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

        }
    }
}
