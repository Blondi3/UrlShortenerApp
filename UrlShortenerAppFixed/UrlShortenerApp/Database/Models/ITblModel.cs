namespace UrlShortenerApp.Database.Models
{
    public interface ITblModel
    {
        int? InternalSQLiteId { get; set; }
        int? Id { get; set; }
    }
}

