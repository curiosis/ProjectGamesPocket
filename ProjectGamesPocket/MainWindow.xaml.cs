using ProjectGamesPocket.Pages;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectGamesPocket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MouseDown += Window_MouseDown;

            Main.Content = new pgLogin();
        }

        private List<Object> PageList = new List<Object>();

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            NewPage(new pgLogin());
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_account_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_games_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_producer_Click(object sender, RoutedEventArgs e)
        {
            NewPage(new pgProducers());
        }

        private void btn_new_Click(object sender, RoutedEventArgs e)
        {

        }
        //xd//
        private void btn_info_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_github_Click(object sender, RoutedEventArgs e)
        {

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

    }
}
