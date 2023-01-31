using PhotographerPortfolioMobile.Models;

namespace PhotographerPortfolioMobile.Services.Interfaces
{
    public interface IScannerService
    {
        Task<QRScannerResponse> GetVideoUrlByQrCode(string storyId);
        Task<string> GetVideoUrlByImage(FileResult image);
        Task<IEnumerable<Story>> GetStories();
    }
}
