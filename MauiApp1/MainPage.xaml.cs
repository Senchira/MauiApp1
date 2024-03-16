using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace MyApp
{
    public partial class MainPage : ContentPage
    {
        private readonly QuoteApi _quoteApi;

        public MainPage()
        {
            InitializeComponent();
            _quoteApi = new QuoteApi();
        }

        private async void OnGetQuoteClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await _quoteApi.GetRandomQuoteWithAuthorAsync();
                QuoteLabel.Text = result.Item1;
                AuthorLabel.Text = result.Item2;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to fetch quote: {ex.Message}", "OK");
            }
        }
    }
}

