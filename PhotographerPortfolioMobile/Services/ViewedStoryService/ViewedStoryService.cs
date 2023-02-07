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

        public Task<ViewedStory> GetViewedStoryById(string viewedStoryId)
        {
            return ViewedStoryRepository.GetViewedStoryByStoryId(viewedStoryId);
        }

        public Task<ViewedStory> GetViewedStoryByStoryId(string storyId)
        {
            return ViewedStoryRepository.GetViewedStoryByStoryId(storyId);
        }

        public Task<List<ViewedStory>> GetViewedStories()
        {
            return ViewedStoryRepository.GetViewedStories();
        }

        public async Task<int> DeleteViewedStory(ViewedStory item)
        {
            var viewedStory = await ViewedStoryRepository.GetViewedStoryById(item.StoryId);

            if (item != null)
                return await ViewedStoryRepository.DeleteViewedStory(item);
            else
            {
                var isSuccessful = 0;
                return isSuccessful;
            }
        }

        public async Task<int> SaveViewedStory(ViewedStory item)
        {
            var viewedStory = await ViewedStoryRepository.GetViewedStoryByStoryId(item.StoryId);

            if (item != null && item.ViewedStoryId != null && viewedStory == null)
                return await ViewedStoryRepository.SaveViewedStory(item);
            else
            {
                var isSuccessful = 0;
                return isSuccessful;
            }
        }

        public async Task<int> UpdateViewedStory(ViewedStory item)
        {
            var viewedStory = await ViewedStoryRepository.GetViewedStoryById(item.StoryId);

            if (item != null)
                return await ViewedStoryRepository.UpdateViewedStory(item);
            else
            {
                var isSuccessful = 0;
                return isSuccessful;
            }
        }

        public async Task<int> RemoveAllViewedStories()
        {
            return await ViewedStoryRepository.DeleteAll();
        }
    }
}
