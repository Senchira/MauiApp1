using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public class QuoteApi
    {
        private readonly HttpClient _httpClient;

        public QuoteApi()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://favqs.com/api/");
        }

        public async Task<Tuple<string, string>> GetRandomQuoteWithAuthorAsync()
        {
            string quoteEndpoint = "https://favqs.com/api/qotd";
            HttpResponseMessage quoteResponse = await _httpClient.GetAsync(quoteEndpoint);
            quoteResponse.EnsureSuccessStatusCode();
            string quoteJson = await quoteResponse.Content.ReadAsStringAsync();

            var quoteData = JsonConvert.DeserializeObject<QuoteData>(quoteJson);
            if (quoteData != null && quoteData.Quote != null && !string.IsNullOrEmpty(quoteData.Quote.Body))
            {
                string quote = quoteData.Quote.Body;
                string author = quoteData.Quote.Author;

                return Tuple.Create(quote, author);
            }
            else
            {
                throw new Exception("Failed to fetch quote: Quote data is null or incomplete.");
            }
        }
    }

    public class QuoteData
    {
        public QuoteData()
        {
            Quote = new Quote();
        }

        public Quote Quote { get; set; }
    }
    public class Quote
    {
        public Quote()
        {
            Body = "";
            Author = "";
        }

        public string Body { get; set; }
        public string Author { get; set; }
    }
}

