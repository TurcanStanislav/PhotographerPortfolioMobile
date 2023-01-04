using PhotographerPortfolioMobile.Services.Interfaces;

namespace PhotographerPortfolioMobile.Services
{
    public class ScannerService : IScannerService
    {
        private string baseUrl { get; set; }
        private string getStoryByQRCodeUrl { get; set; }

        public ScannerService()
        {
            baseUrl = "https://4181-69-41-53-4.eu.ngrok.io";
            getStoryByQRCodeUrl = Path.Combine(baseUrl, "ImageScanner/GetStoryByQRCode");
        }

        public async Task<string> GetVideoByQrCode(string storyId)
        {
            var client = new HttpClient();

            var fullUrl = string.Format("{0}?storyId={1}", getStoryByQRCodeUrl, storyId);
            var response = await client.GetAsync(fullUrl);
            var relativePath = await response.Content.ReadAsStringAsync();
            return string.Concat(baseUrl, relativePath);
        }
    }
}
