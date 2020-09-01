using ProjectGamesPocket.Assets.Scripts;
using ProjectGamesPocket.DAL.Repositories;
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
    /// Logika interakcji dla klasy pgRegister.xaml
    /// </summary>
    public partial class pgRegister : Page
    {
        private string login, password, retypePassword, hashPassword;

        public pgRegister()
        {
            InitializeComponent();
        }

        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            login = username_textbox.Text;
            password = Password_textbox.Password;
            retypePassword = retypePassword_textbox.Password;

            pgLogin pgLogin = new pgLogin();

            if(Assets.Scripts.Login.IsPasswordCorrect(password,retypePassword) &&
                Assets.Scripts.Login.IsCorrectLogin(login))
            {
                hashPassword = Assets.Scripts.Login.HashPassword(password);
                UsersRepo.CreateUser(login, hashPassword);

                NavigationService.Navigate(pgLogin);
            }
        }
    }
}
