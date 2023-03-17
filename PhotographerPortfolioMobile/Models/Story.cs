namespace PhotographerPortfolioMobile.Models
{
    public class Story
    {
        public string StoryId { get; set; }
        public string StoryTitle { get; set; }
        public string Description { get; set; }
        public List<ImageData> Images { get; set; }
        public string VideoPath { get; set; }
        public string QRCode { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? WatchedTime { get; set; }
    }

    public class ImageData
    {
        public string ImageUrl { get; set; }
        public string ThumbUrl { get; set; }
    }
}
