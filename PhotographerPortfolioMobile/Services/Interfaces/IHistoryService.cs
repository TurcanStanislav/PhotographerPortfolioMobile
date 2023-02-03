using PhotographerPortfolioMobile.Models;
using System.Collections.ObjectModel;

namespace PhotographerPortfolioMobile.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<ObservableCollection<Story>> GetViewedStories();
    }
}
