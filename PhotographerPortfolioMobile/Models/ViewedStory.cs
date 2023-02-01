using SQLite;

namespace PhotographerPortfolioMobile.Models
{
    public class ViewedStory
    {
        [PrimaryKey]
        public string ViewedStoryId { get; set; }
        public string StoryId { get; set; }
        public DateTimeOffset WatchedTime { get; set; }
    }
}
