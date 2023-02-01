using PhotographerPortfolioMobile.Database;
using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Repositories.Interfaces;
using SQLite;

namespace PhotographerPortfolioMobile.Repositories
{
    public class ViewedStoryRepository : IViewedStoryRepository
    {
        private readonly SQLiteAsyncConnection DbConnection;

        public ViewedStoryRepository(AppDbContext appDB)
        {
            DbConnection = appDB.Database;
        }

        public async Task<List<ViewedStory>> GetViewedStories()
        {
            return await DbConnection.Table<ViewedStory>().ToListAsync();
        }

        public async Task<ViewedStory> GetViewedStory(string viewedStoryId)
        {
            return await DbConnection.Table<ViewedStory>().Where(i => i.ViewedStoryId == viewedStoryId).FirstOrDefaultAsync();
        }

        public async Task<int> SaveViewedStory(ViewedStory item)
        {
            if (item.ViewedStoryId != null)
                return await DbConnection.UpdateAsync(item);
            else
            {
                var a = await DbConnection.InsertAsync(item);
                return a;
            }
        }

        public async Task<int> DeleteViewedStory(ViewedStory item)
        {
            return await DbConnection.DeleteAsync(item);
        }
    }
}
