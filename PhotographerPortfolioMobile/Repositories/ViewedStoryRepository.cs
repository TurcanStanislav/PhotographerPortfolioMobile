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

        public async Task<ViewedStory> GetViewedStoryById(string viewedStoryId)
        {
            return await DbConnection.Table<ViewedStory>().Where(i => i.ViewedStoryId == viewedStoryId).FirstOrDefaultAsync();
        }

        public async Task<ViewedStory> GetViewedStoryByStoryId(string storyId)
        {
            return await DbConnection.Table<ViewedStory>().Where(i => i.StoryId == storyId).FirstOrDefaultAsync();
        }

        public async Task<int> SaveViewedStory(ViewedStory item)
        {
            return await DbConnection.InsertAsync(item);
        }

        public async Task<int> UpdateViewedStory(ViewedStory item)
        {
            return await DbConnection.UpdateAsync(item);
        }

        public async Task<int> DeleteViewedStory(ViewedStory item)
        {
            return await DbConnection.DeleteAsync(item);
        }

        public async Task<int> DeleteAll()
        {
            return await DbConnection.Table<ViewedStory>().DeleteAsync(x => x.ViewedStoryId != null);
        }
    }
}
