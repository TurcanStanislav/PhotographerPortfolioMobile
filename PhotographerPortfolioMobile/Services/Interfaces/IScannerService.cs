using PhotographerPortfolioMobile.Models;

namespace PhotographerPortfolioMobile.Services.Interfaces
{
    public interface IScannerService
    {
        Task<string> GetVideoByQrCode(string storyId);
        Task<IEnumerable<Story>> GetStories();
    }
}
