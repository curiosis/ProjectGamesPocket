using ProjectGamesPocket.DAL.Repositories;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ProjectGamesPocket.Pages
{
    public partial class PgRegister : Page
    {
        private string login, password, retypePassword, hashPassword;

        public PgRegister()
        {
            InitializeComponent();
        }

        private void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            login = username_textbox.Text;
            password = Password_textbox.Password;
            retypePassword = retypePassword_textbox.Password;

            PgLogin pgLogin = new PgLogin();

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
