using UrlShortenerApp.Database.Models;
using UrlShortenerApp.Core.ViewModels;

namespace UrlShortenerApp.Areas.Pages
{
    public partial class ViewPastUrlsPage : ContentPage
    {
        List<ViewPastUrlsViewModel> model = new List<ViewPastUrlsViewModel>();

        public ViewPastUrlsPage(List<ViewPastUrlsViewModel> urlShortenerViewModel)
        {
            InitializeComponent();

            model = urlShortenerViewModel;

            viewPastShortenedUrlsCollectionView.ItemsSource = model;

            var shortenedUrls = App.Database.GetItemsAsync<TblPastShortenedUrls>().Result;
            if (shortenedUrls != null)
            {
                shortenedUrls.Select(su =>
                {
                    model.Add(new ViewPastUrlsViewModel()
                    {
                        DateUrlSaved = su.DateUrlSaved,
                        OriginalUrl = su.OriginalUrl,
                        ToBeShortenedUrl = su.ShortenedUrl
                    });

                    return su;
                }).ToList();
            }
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
        }
    }
}
