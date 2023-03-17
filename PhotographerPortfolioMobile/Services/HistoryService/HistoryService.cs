using CommunityToolkit.Maui.Core.Extensions;
using Newtonsoft.Json;
using PhotographerPortfolioMobile.Extensions;
using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
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

        public async Task<ObservableCollection<Story>> GetViewedStories(Func<ViewedStory, bool> predicate = default)
        {
            var viewedStories = await ViewedStoryService.GetViewedStories();
            IEnumerable<string> ids;
            if (predicate != null)
                ids = viewedStories.Where(predicate).Select(x => x.StoryId).ToList();
            else
                ids = viewedStories.Select(x => x.StoryId).ToList();

            var data = new { Ids = ids, TimeZoneId = TimeZoneInfo.Local.Id };

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(Constants.GetStoriesByIdsUrl, content);
            ObservableCollection<Story> stories;

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                stories = JsonConvert.DeserializeObject<ObservableCollection<Story>>(json);

                foreach (var story in stories)
                {
                    story.CreationTime = story.CreationTime;
                    story.WatchedTime = viewedStories.Where(x => x.StoryId == story.StoryId)
                                                     .FirstOrDefault().WatchedTime
                                                     .ConvertToTimeZone();

                    foreach (var image in story.Images)
                    {
                        image.ImageUrl = string.Concat(Constants.BaseUrl, image.ImageUrl);
                        image.ThumbUrl = string.Concat(Constants.BaseUrl, image.ThumbUrl);
                    }

                    story.VideoPath = string.Concat(Constants.BaseUrl, story.VideoPath);
                }

                stories = stories.OrderByDescending(x => x.WatchedTime).ToObservableCollection();
            }
            else
            {
                stories = new();
            }

            return stories;
        }
        public async Task<IEnumerable<Story>> GetStories()
        {
            var response = await Client.GetAsync(Constants.GetStoriesUrl);
            var stories = await response.Content.ReadFromJsonAsync<List<Story>>();
            return stories;
        }
    }
}
