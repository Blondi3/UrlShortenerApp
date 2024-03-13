namespace UrlShortenerApp.Core.ViewModels
{
    public class UrlShortenerViewModel: ObservableProperty
    {
        #region Properties 

        private bool hasNotShortenedUrl = true;
        public bool HasNotShortenedUrl
        {
            get
            {
                return hasNotShortenedUrl;
            }
            set
            {
                hasNotShortenedUrl = value;
                OnPropertyChanged(nameof(HasNotShortenedUrl));

                if (!hasNotShortenedUrl)
                {
                    originalUrlLabel = "Your original url";
                    ToBeShortenedUrl = "Your Shortened url";
                }
            }
        }

        private string originalUrlLabel = "";
        public string OriginalUrlLabel
        {
            get
            {
                return originalUrlLabel;
            }
            set
            {
                originalUrlLabel = value;
                OnPropertyChanged(nameof(OriginalUrlLabel));
            }
        }

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

        private string toBeShortenedUrlLabel = "Please enter your url";
        public string ToBeShortenedUrlLabel
        {
            get
            {
                return toBeShortenedUrlLabel;
            }
            set
            {
                toBeShortenedUrlLabel = value;
                OnPropertyChanged(nameof(ToBeShortenedUrlLabel));
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

        #endregion
    }
}
