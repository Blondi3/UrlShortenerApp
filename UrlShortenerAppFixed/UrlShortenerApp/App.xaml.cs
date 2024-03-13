using Microsoft.Extensions.Configuration;
using UrlShortenerApp.Database;

namespace UrlShortenerApp
{
    public partial class App : Application
    {
        private string apiKey = "12a65cbd490f477ca424b5a5f0604f8c";
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
