using Microsoft.Extensions.Configuration;
using UrlShortenerApp.Database;

namespace UrlShortenerApp
{
    public partial class App : Application
    {
        private string apiKey = "e858d127adf44b51b48dd02e3e291867";
        public string ApiKey
        {
            get
            {
                return apiKey;
            }
            set
            {
                apiKey = value;
            }
        }

        static UrlShortenerAppDbProvider database;
        public static UrlShortenerAppDbProvider Database
        {
            get
            {
                if (database == null)
                {
                    database = new UrlShortenerAppDbProvider();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
