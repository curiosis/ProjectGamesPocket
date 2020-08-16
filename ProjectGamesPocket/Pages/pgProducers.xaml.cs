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
    /// <summary>
    /// Logika interakcji dla klasy pgProducers.xaml
    /// </summary>
    public partial class pgProducers : Page
    {
        public pgProducers()
        {
            InitializeComponent();
            producersListView.ItemsSource = ProducersRepo.GetAll();
        }
    }
}
