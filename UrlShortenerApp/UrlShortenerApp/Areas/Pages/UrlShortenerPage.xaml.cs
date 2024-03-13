using Newtonsoft.Json;
using System.Net;
using UrlShortenerApp.Core.ViewModels;
using System.Text;
using UrlShortenerApp.Database.Models;

namespace UrlShortenerApp.Areas.Pages
{
    public partial class UrlShortenerPage : ContentPage
    {
        UrlShortenerViewModel model;
        public UrlShortenerPage(UrlShortenerViewModel urlShortenerViewModel)
        {
            InitializeComponent();

            model = urlShortenerViewModel;

            BindingContext = model;
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
        }

        private async void ShortenUrlButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.ToBeShortenedUrl))
                {
                    var payload = new
                    {
                        destination = model.ToBeShortenedUrl,
                        domain = new
                        {
                            fullName = "rebrand.ly"
                        }
                    };

                    using (var httpClient = new HttpClient { BaseAddress = new Uri("https://api.rebrandly.com") })
                    {
                        httpClient.DefaultRequestHeaders.Add("apikey", ((UrlShortenerApp.App)App.Current).ApiKey);

                        var body = new StringContent(
                            JsonConvert.SerializeObject(payload), UnicodeEncoding.UTF8, "application/json");

                        using (var response = await httpClient.PostAsync("/v1/links", body))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var link = JsonConvert.DeserializeObject<dynamic>(
                                    await response.Content.ReadAsStringAsync());

                                model.HasNotShortenedUrl = !model.HasNotShortenedUrl;
                                model.OriginalUrl = payload.destination;
                                model.ToBeShortenedUrl = link.shortUrl;

                                await App.Database.SaveItemAsync(new TblPastShortenedUrls
                                {
                                    OriginalUrl = model.OriginalUrl,
                                    ShortenedUrl = model.ToBeShortenedUrl,
                                    DateUrlSaved = DateTime.Now
                                });
                            }
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Please enter a url to shorten", "OK");
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BackButtonClicked(object sender, EventArgs e)
        {
            model = new UrlShortenerViewModel();
        }

        private void NavigateToViewPastUrlsPageClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(ViewPastUrlsPage));
        }
    }
}
