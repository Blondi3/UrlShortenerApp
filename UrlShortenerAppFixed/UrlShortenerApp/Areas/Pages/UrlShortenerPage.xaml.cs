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
                //    if (!string.IsNullOrEmpty(model.ToBeShortenedUrl))
                //    {
                //        var result = model.ShortenUrlHttpRequestSentAndIsSuccessful(((UrlShortenerApp.App)App.Current).ApiKey);

                //        if (result.Result)
                //        {
                model.OriginalUrl = "TestOriginalUrl2";
                model.ToBeShortenedUrl = "TestShortenedUrl2";
                model.HasNotShortenedUrl = !model.HasNotShortenedUrl;

                await App.Database.SaveItemAsync(new TblPastShortenedUrls
                {
                    OriginalUrl = model.OriginalUrl,
                    ShortenedUrl = model.ToBeShortenedUrl,
                    DateUrlSaved = DateTime.Now
                });
                //}
                //    else
                //    {
                //        await DisplayAlert("Error", "Request failed, please try again", "OK");
                //    }
                //}
                //else
                //{
                //    await DisplayAlert("Error", "Please enter a url to shorten", "OK");
                //}
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BackButtonClicked(object sender, EventArgs e)
        {
            model = new UrlShortenerViewModel();

            BindingContext = model;
        }

        private void NavigateToViewPastUrlsPageClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(ViewPastUrlsPage));
        }
    }
}
