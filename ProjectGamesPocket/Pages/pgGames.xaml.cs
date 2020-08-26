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
    /// <summary>
    /// Logika interakcji dla klasy pgGames.xaml
    /// </summary>
    public partial class pgGames : Page
    {
        public pgGames()
        {
            InitializeComponent();
            gamesListView.ItemsSource = GamesRepo.GetAll();
            
        }

        private void btnAddGame_Click(object sender, RoutedEventArgs e)
        {
            pgAddGame pgAddGame = new pgAddGame();
            NavigationService.Navigate(pgAddGame);
        }

        private void gamesListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
