using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Services.Interfaces;
using System.Net.Http.Json;

namespace PhotographerPortfolioMobile.Services.ScannerService
{
    public class ScannerService : IScannerService
    {
        public ScannerService()
        {
        }

        public async Task<string> GetVideoByQrCode(string storyId)
        {
            var client = new HttpClient();

            var fullUrl = string.Format("{0}?storyId={1}", Constants.GetStoryByQRCodeUrl, storyId);
            var response = await client.GetAsync(fullUrl);
            var relativeVideoPath = await response.Content.ReadAsStringAsync();
            return string.Concat(Constants.BaseUrl, relativeVideoPath);
        }

        public async Task<IEnumerable<Story>> GetStories()
        {
            var client = new HttpClient();

            var response = await client.GetAsync(Constants.GetStoriesUrl);
            var stories = await response.Content.ReadFromJsonAsync<List<Story>>();
            return stories;
        }
    }
}
