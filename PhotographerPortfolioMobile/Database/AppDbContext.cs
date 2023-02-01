using PhotographerPortfolioMobile.Models;
using SQLite;

namespace PhotographerPortfolioMobile.Database
{
    public class AppDbContext
    {
        public readonly SQLiteAsyncConnection Database;

        public AppDbContext()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath);
            Database.CreateTableAsync<ViewedStory>().Wait();
        }
    }
}
