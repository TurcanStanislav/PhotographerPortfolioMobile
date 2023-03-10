namespace PhotographerPortfolioMobile.Models
{
    public class Story
    {
        public string StoryId { get; set; }
        public string StoryTitle { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ThumbPath { get; set; }
        public string VideoPath { get; set; }
        public DateTimeOffset? CreationTime { get; set; }
        public string QRCode { get; set; }
    }
}
