namespace PhotographerPortfolioMobile.Models
{
    public static class Constants
    {
        public const string BaseUrl = "https://e206-69-41-53-4.eu.ngrok.io";
        public const string GetVideoByQRCodeUrl = BaseUrl + "/ImageScanner/GetVideoUrlByQRCode";
        public const string GetVideoByImageUrl = BaseUrl + "/ImageScanner/GetVideoUrlByImage";
        public const string GetStoriesUrl = BaseUrl + "/ImageScanner/GetStories";
        public const string GetStoriesByIdsUrl = BaseUrl + "/ImageScanner/GetStoriesByIds";

        public const string DatabaseFilename = "PhotographerPortfolioMobileDB.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);
    }
}
