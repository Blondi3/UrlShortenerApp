using System.Text;
using Newtonsoft.Json;

namespace UrlShortenerApp.Core.ViewModels
{
    public class UrlShortenerViewModel : ObservableProperty
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
                    OnPropertyChanged(nameof(OriginalUrlLabel));
                    ToBeShortenedUrlLabel = "Your Shortened url";
                    OnPropertyChanged(nameof(ToBeShortenedUrlLabel));
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

        public async Task<bool> ShortenUrlHttpRequestSentAndIsSuccessful(string apiKey)
        {
            var payload = new
            {
                destination = ToBeShortenedUrl,
                domain = new
                {
                    fullName = "rebrand.ly"
                }
            };

            using (var httpClient = new HttpClient { BaseAddress = new Uri("https://api.rebrandly.com") })
            {
                httpClient.DefaultRequestHeaders.Add("apikey", apiKey);

                var body = new StringContent(
                    JsonConvert.SerializeObject(payload), UnicodeEncoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("/v1/links", body))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var link = JsonConvert.DeserializeObject<dynamic>(
                        await response.Content.ReadAsStringAsync());

                        HasNotShortenedUrl = !HasNotShortenedUrl;
                        OriginalUrl = payload.destination;
                        ToBeShortenedUrl = link.shortUrl;

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
