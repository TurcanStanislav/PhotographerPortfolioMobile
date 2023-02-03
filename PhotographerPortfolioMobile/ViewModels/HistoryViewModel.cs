using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Services.Interfaces;
using PhotographerPortfolioMobile.Views;
using System.Collections.ObjectModel;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class HistoryViewModel : BaseViewModel
    {
        private readonly IHistoryService HistoryService;

        [ObservableProperty]
        public ObservableCollection<Story> stories = new();

        [ObservableProperty]
        public bool isRefreshing = false;

        public HistoryViewModel(IHistoryService historyService)
        {
            HistoryService = historyService;
        }

        [RelayCommand]
        public async Task GetViewedStories()
        {
            if (Stories.Count == 0)
                Stories = await HistoryService.GetViewedStories();
        }

        [RelayCommand]
        public async Task RefreshViewedStories()
        {
            IsRefreshing = true;
            Stories = await HistoryService.GetViewedStories();
            IsRefreshing = false;
        }

        [RelayCommand]
        public async Task GoToStoryDetails(Story story)
        {
            if (story == null)
                return;

            await Shell.Current.GoToAsync(nameof(StoryDetailsPage), true, new Dictionary<string, object>
            {
                {"Story", story}
            });

            IsRefreshing = true;
            Stories = await HistoryService.GetViewedStories();
            IsRefreshing = false;
        }
    }
}
