using PhotographerPortfolioMobile.Models;

namespace PhotographerPortfolioMobile.Repositories.Interfaces
{
    public interface IViewedStoryRepository
    {
        Task<List<ViewedStory>> GetViewedStories();

        Task<ViewedStory> GetViewedStoryById(string viewedStoryId);

        Task<ViewedStory> GetViewedStoryByStoryId(string storyId);

        Task<int> SaveViewedStory(ViewedStory item);

        Task<int> UpdateViewedStory(ViewedStory item);

        Task<int> DeleteViewedStory(ViewedStory item);
    }
}
