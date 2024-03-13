using UrlShortenerApp.Database.Models;

namespace UrlShortenerApp.Database
{
    public static class UrlShortenerAppTables
    {
        public static List<Type> TableTypes = new List<Type>
        {
             typeof(TblPastShortenedUrls),
        };
    }
}