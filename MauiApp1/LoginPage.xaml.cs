using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace MyApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (username == "admin" && password == "password")
            {
                // Если логин и пароль верные, переходим на другой экран
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }
    }
}


