using SQLite;

namespace PhotographerPortfolioMobile.Models
{
    public class ViewedStory
    {
        [PrimaryKey]
        public string ViewedStoryId { get; set; } = Guid.NewGuid().ToString();
        public string StoryId { get; set; }
        public bool IsFavorite { get; set; } = false;
        public DateTime WatchedTime { get; set; }
    }
}
