using ProjectGamesPocket.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProjectGamesPocket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string url = $"https://github.com/curiosis/ProjectGamesPocket";

        public MainWindow()
        {
            InitializeComponent();
            MouseDown += Window_MouseDown;

            Main.Content = new pgHome();
        }

        private readonly List<Object> PageList = new List<Object>();

        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            NewPage(new pgLogin());
        }

        private void Btn_home_Click(object sender, RoutedEventArgs e)
        {
            NewPage(new pgHome());
        }

        private void Btn_account_Click(object sender, RoutedEventArgs e)
        {
            NewPage(new Account());
        }

        private void Btn_games_Click(object sender, RoutedEventArgs e)
        {
            NewPage(new pgGames());
        }

        private void Btn_producer_Click(object sender, RoutedEventArgs e)
        {
            NewPage(new PgProducers());
        }

        private void Btn_info_Click(object sender, RoutedEventArgs e)
        {
            NewPage(new PgInfo());
        }

        private void Btn_github_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimize_button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void NewPage(Page newPage)
        {
            if (newPage.ToString() != Main.Content.ToString())
            {
                PageList.Add(Main.Content);
                Main.Content = newPage;
            }
        }

        public void SetVisibilityAfterLogin()
        {
            btn_account.Visibility = Visibility.Visible;
            btn_producer.Visibility = Visibility.Visible;
            btn_games.Visibility = Visibility.Visible;
            btn_login.IsEnabled = false;
        }
    }
}
