using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Repositories.Interfaces;
using PhotographerPortfolioMobile.Services.Interfaces;

namespace PhotographerPortfolioMobile.Services.ViewedStoryService
{
    public class ViewedStoryService : IViewedStoryService
    {
        private readonly IViewedStoryRepository ViewedStoryRepository;

        public ViewedStoryService(IViewedStoryRepository viewedStoryRepository)
        {
            ViewedStoryRepository = viewedStoryRepository;
        }

        public Task<ViewedStory> GetViewedStory(string viewedStoryId)
        {
            return ViewedStoryRepository.GetViewedStory(viewedStoryId);
        }

        public Task<List<ViewedStory>> GetViewedStories()
        {
            return ViewedStoryRepository.GetViewedStories();
        }

        public Task<int> DeleteViewedStory(ViewedStory item)
        {
            return ViewedStoryRepository.DeleteViewedStory(item);
        }

        public Task<int> SaveViewedStory(ViewedStory item)
        {
            return ViewedStoryRepository.SaveViewedStory(item);
        }
    }
}
