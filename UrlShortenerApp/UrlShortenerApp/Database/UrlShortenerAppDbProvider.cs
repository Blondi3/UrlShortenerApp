using UrlShortenerApp.Database.Models;
using SQLite;

namespace UrlShortenerApp.Database
{
    public class UrlShortenerAppDbProvider
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public UrlShortenerAppDbProvider()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => UrlShortenerAppTables.TableTypes.Contains(m.MappedType)))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, UrlShortenerAppTables.TableTypes.Where(tt => !Database.TableMappings.Select(tm => tm.MappedType).Contains(tt)).ToArray()).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<T>> GetItemsAsync<T>() where T : ITblModel, new()
        {
            return Database.Table<T>().ToListAsync();
        }

        public async Task<int?> SaveItemAsync<T>(T item) where T : ITblModel
        {
            if (item.Id != null)
            {
                await Database.UpdateAsync(item);
            }
            else
            {
                await Database.InsertAsync(item);
            }

            return item.Id;
        }
    }
}
