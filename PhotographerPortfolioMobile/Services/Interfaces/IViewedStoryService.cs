using PhotographerPortfolioMobile.Models;

namespace PhotographerPortfolioMobile.Services.Interfaces
{
    public interface IViewedStoryService
    {
        Task<List<ViewedStory>> GetViewedStories();

        Task<ViewedStory> GetViewedStoryById(string viewedStoryId);

        Task<int> SaveViewedStory(ViewedStory item);

        Task<int> UpdateViewedStory(ViewedStory item);

        Task<int> DeleteViewedStory(ViewedStory item);
    }
}
