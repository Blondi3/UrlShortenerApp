using SQLite;

namespace UrlShortenerApp.Database.Models
{
    [Table(nameof(TblPastShortenedUrls))]
    public class TblPastShortenedUrls : ITblModel
    {
        [AutoIncrement, PrimaryKey]
        public int? InternalSQLiteId
        {
            get { return Id; }
            set
            {
                if (value != null)
                    Id = value;
            }
        }

        int? id;
        [Unique]
        public int? Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value != null)
                    id = value;
            }
        }

        public string OriginalUrl
        { get; set; }

        public string ShortenedUrl
        { get; set; }

        public DateTime DateUrlSaved
        { get; set; }
    }
}
