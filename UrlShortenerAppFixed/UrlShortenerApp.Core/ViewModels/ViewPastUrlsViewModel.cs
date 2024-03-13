namespace UrlShortenerApp.Core.ViewModels
{
    public class ViewPastUrlsViewModel : ObservableProperty
    {
        #region Properties 

        private string originalUrl = "";
        public string OriginalUrl
        {
            get
            {
                return originalUrl;
            }
            set
            {
                originalUrl = value;
                OnPropertyChanged(nameof(OriginalUrl));
            }
        }

        private string toBeShortenedUrl = "";
        public string ToBeShortenedUrl
        {
            get
            {
                return toBeShortenedUrl;
            }
            set
            {
                toBeShortenedUrl = value;
                OnPropertyChanged(nameof(ToBeShortenedUrl));
            }
        }

        private DateTime dateUrlSaved;
        public DateTime DateUrlSaved
        {
            get
            {
                return dateUrlSaved;
            }
            set
            {
                dateUrlSaved = value;
                OnPropertyChanged(nameof(DateUrlSaved));
            }
        }

        #endregion
    }
}
