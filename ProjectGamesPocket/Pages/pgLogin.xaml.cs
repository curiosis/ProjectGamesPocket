using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ProjectGamesPocket.Pages
{
    public partial class PgLogin : Page
    {
        private string login, password;

        public PgLogin()
        {
            InitializeComponent();
        }

        private void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            PgRegister pgregister = new PgRegister();
            NavigationService.Navigate(pgregister);
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            login = Login_textbox.Text;
            password = Password_textbox.Password;

            var hash = Assets.Scripts.Login.HashPassword(password);
            var hashfromDB = Assets.Scripts.Login.GetPassword(login);
            if (Assets.Scripts.Login.CheckPasswords(hash, hashfromDB))
            {
                Assets.Scripts.Login.loginStatus = true;
                Assets.Scripts.Login.UserLogin = login;

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                        (window as MainWindow).SetVisibilityAfterLogin();
                }

                pgHome newPage = new pgHome();
                NavigationService.Navigate(newPage);
            }
        }
    }
}
