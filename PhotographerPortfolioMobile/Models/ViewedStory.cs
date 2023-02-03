using SQLite;

namespace PhotographerPortfolioMobile.Models
{
    public class ViewedStory
    {
        [PrimaryKey]
        public string ViewedStoryId { get; set; } = Guid.NewGuid().ToString();
        public string StoryId { get; set; }
        public DateTime WatchedTime { get; set; }
    }
}
