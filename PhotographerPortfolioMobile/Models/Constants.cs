namespace PhotographerPortfolioMobile.Models
{
    public static class Constants
    {
        public const string BaseUrl = "https://e034-69-41-53-4.eu.ngrok.io";
        public const string GetVideoByQRCodeUrl = BaseUrl + "/ImageScanner/GetVideoUrlByQRCode";
        public const string GetVideoByImageUrl = BaseUrl + "/ImageScanner/GetVideoUrlByImage";
        public const string GetStoriesUrl = BaseUrl + "/ImageScanner/GetStories";
    }
}
