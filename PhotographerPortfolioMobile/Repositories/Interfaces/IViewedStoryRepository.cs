using PhotographerPortfolioMobile.Models;

namespace PhotographerPortfolioMobile.Repositories.Interfaces
{
    public interface IViewedStoryRepository
    {
        Task<List<ViewedStory>> GetViewedStories();

        Task<ViewedStory> GetViewedStory(string viewedStoryId);

        Task<int> SaveViewedStory(ViewedStory item);

        Task<int> DeleteViewedStory(ViewedStory item);
    }
}
