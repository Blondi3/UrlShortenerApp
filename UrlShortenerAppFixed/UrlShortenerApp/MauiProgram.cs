using Microsoft.Extensions.Logging;
using UrlShortenerApp.Areas.Pages;
using UrlShortenerApp.Core.ViewModels;

namespace UrlShortenerApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<UrlShortenerViewModel>();
            builder.Services.AddTransient<List<ViewPastUrlsViewModel>>();

            builder.Services.AddSingleton<UrlShortenerPage>();
            builder.Services.AddTransient<ViewPastUrlsPage>();

            return builder.Build();
        }
    }
}
