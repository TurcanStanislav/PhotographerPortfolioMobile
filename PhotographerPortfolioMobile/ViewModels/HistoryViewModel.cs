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
        private readonly IViewedStoryService ViewedStoryService;

        [ObservableProperty]
        public ObservableCollection<Story> stories = new();

        [ObservableProperty]
        public bool isRefreshing = false;

        public HistoryViewModel(IHistoryService historyService, IViewedStoryService viewedStoryService)
        {
            HistoryService = historyService;
            ViewedStoryService = viewedStoryService;
        }

        [RelayCommand]
        public async Task GetViewedStories()
        {
            IsBusy = true;
            if (Stories.Count == 0)
                Stories = await HistoryService.GetViewedStories();
            IsBusy = false;
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

        [RelayCommand]
        public async Task ClearHistory()
        {
            IsBusy = true;
            await ViewedStoryService.RemoveAllViewedStories();
            Stories.Clear();
            IsBusy = false;
        }

        [RelayCommand]
        public async Task AddToFavorites(string storyId)
        {
            await Task.FromResult(true);
        }

        [RelayCommand]
        public async Task DeleteViewedStory(string storyId)
        {
            var viewedStoryId = await ViewedStoryService.GetViewedStoryByStoryId(storyId);
            await ViewedStoryService.DeleteViewedStory(viewedStoryId);
            var story = Stories.Where(x => x.StoryId == storyId).FirstOrDefault();
            Stories.Remove(story);
        }
    }
}
