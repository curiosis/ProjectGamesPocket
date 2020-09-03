﻿using ProjectGamesPocket.Assets.Scripts;
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
    /// Logika interakcji dla klasy Account.xaml
    /// </summary>
    public partial class Account : Page
    {

        public Account()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Assets.Scripts.Pesel.PESEL(check.Text))
            {
                result.Text = "CORRECT";
            }
            else
            {
                result.Text = "INCORRECT";
            }
        }
    }
}