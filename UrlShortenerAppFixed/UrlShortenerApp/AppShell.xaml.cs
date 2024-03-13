using UrlShortenerApp.Areas.Pages;

namespace UrlShortenerApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ViewPastUrlsPage), typeof(ViewPastUrlsPage));
            Routing.RegisterRoute(nameof(UrlShortenerPage), typeof(UrlShortenerPage));
        }
    }
}
