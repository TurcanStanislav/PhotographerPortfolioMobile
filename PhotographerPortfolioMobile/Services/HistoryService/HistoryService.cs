using CommunityToolkit.Maui.Core.Extensions;
using Newtonsoft.Json;
using PhotographerPortfolioMobile.Extensions;
using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Text;

namespace PhotographerPortfolioMobile.Services.HistoryService
{
    public class HistoryService : IHistoryService
    {
        private readonly IViewedStoryService ViewedStoryService;
        private readonly HttpClient Client;

        public HistoryService(IViewedStoryService viewedStoryService, HttpClient client)
        {
            ViewedStoryService = viewedStoryService;
            Client = client;
            Client.DefaultRequestHeaders.Add("ngrok-skip-browser-warning", "true");
            Client.DefaultRequestHeaders.Add("X-Ngrok-Auth", "2Jrkkhe3SjQFOyYw4own0XKsnfT_7djFeGu8wfMqjYo7F6WQ2");
        }

        public async Task<ObservableCollection<Story>> GetViewedStories()
        {
            var viewedStories = await ViewedStoryService.GetViewedStories();
            var ids = viewedStories.Select(x => x.StoryId).ToList();

            var data = new { Ids = ids, TimeZoneId = TimeZoneInfo.Local.Id };

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(Constants.GetStoriesByIdsUrl, content);

            string json = await response.Content.ReadAsStringAsync();
            var stories = JsonConvert.DeserializeObject<ObservableCollection<Story>>(json);

            foreach (var story in stories)
            {
                story.CreationTime = story.CreationTime;
                story.WatchedTime = viewedStories.Where(x => x.StoryId == story.StoryId)
                                                 .FirstOrDefault().WatchedTime
                                                 .ConvertToTimeZone();
                story.ImagePath = string.Concat(Constants.BaseUrl, story.ImagePath);
                story.ThumbPath = string.Concat(Constants.BaseUrl, story.ThumbPath);
                story.VideoPath = string.Concat(Constants.BaseUrl, story.VideoPath);
            }

            stories = stories.OrderByDescending(x => x.WatchedTime).ToObservableCollection();

            return stories;
        }
    }
}
