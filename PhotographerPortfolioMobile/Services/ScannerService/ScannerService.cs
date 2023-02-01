using Newtonsoft.Json;
using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Services.Interfaces;
using PhotographerPortfolioMobile.Tools;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PhotographerPortfolioMobile.Services.ScannerService
{
    public class ScannerService : IScannerService
    {
        private HttpClient Client { get; }

        public ScannerService(HttpClient client)
        {
            Client = client;
            Client.DefaultRequestHeaders.Add("ngrok-skip-browser-warning", "true");
            Client.DefaultRequestHeaders.Add("X-Ngrok-Auth", "2Jrkkhe3SjQFOyYw4own0XKsnfT_7djFeGu8wfMqjYo7F6WQ2");
        }

        public async Task<QRScannerResponse> GetVideoUrlByQrCode(string storyId)
        {
            var fullUrl = string.Format("{0}?storyId={1}", Constants.GetVideoByQRCodeUrl, storyId);
            var response = await Client.GetAsync(fullUrl);
            string json = await response.Content.ReadAsStringAsync();
            var qrScannerResponse = JsonConvert.DeserializeObject<QRScannerResponse>(json);
            return qrScannerResponse;
        }

        public async Task<ImageScannerResponse> GetVideoUrlByImage(FileResult image)
        {
            var imageBytes = await ImageConvertor.ScaleImage(image);

            var content = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(imageBytes);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "image",
                FileName = "frame.png",
            };

            content.Add(fileContent);

            var response = await Client.PostAsync(Constants.GetVideoByImageUrl, content);

            string json = await response.Content.ReadAsStringAsync();
            var imageScannerResponse = JsonConvert.DeserializeObject<ImageScannerResponse>(json);
            return imageScannerResponse;
        }

        public async Task<IEnumerable<Story>> GetStories()
        {
            var response = await Client.GetAsync(Constants.GetStoriesUrl);
            var stories = await response.Content.ReadFromJsonAsync<List<Story>>();
            return stories;
        }
    }
}