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
using ProjectGamesPocket.DAL;
using ProjectGamesPocket.Pages;

namespace ProjectGamesPocket.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy pgLogin.xaml
    /// </summary>
    public partial class pgLogin : Page
    {
        private string login, password;

        public pgLogin()
        {
            InitializeComponent();
            //DBConnection.AdminLogin();
        }

        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            pgRegister pgregister = new pgRegister();
            NavigationService.Navigate(pgregister);
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            login = Login_textbox.Text;
            password = Password_textbox.Password;

            var hash = Assets.Scripts.Login.HashPassword(password);
            var hashfromDB = Assets.Scripts.Login.GetPassword(login);
            if (Assets.Scripts.Login.CheckPasswords(hash, hashfromDB))
            {
                Assets.Scripts.Login.loginStatus = true;
                Assets.Scripts.Login.userLogin = login;

                /*foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                        (window as MainWindow).SetVisibilityAfterLogin();
                }*/

                pgHome newPage = new pgHome();
                NavigationService.Navigate(newPage);
            }
        }
    }
}
