using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Services.Interfaces;
using PhotographerPortfolioMobile.Views;
using System.Collections.ObjectModel;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class FavoriteStoriesViewModel : BaseViewModel
    {
        private readonly IHistoryService HistoryService;
        private readonly IViewedStoryService ViewedStoryService;

        [ObservableProperty]
        public ObservableCollection<Story> stories = new();

        [ObservableProperty]
        public bool isRefreshing = false;

        public FavoriteStoriesViewModel(IHistoryService historyService, IViewedStoryService viewedStoryService)
        {
            HistoryService = historyService;
            ViewedStoryService = viewedStoryService;
        }

        [RelayCommand]
        public async Task GetFavoriteViewedStories()
        {
            IsBusy = true;
            if (Stories.Count == 0)
                Stories = await HistoryService.GetViewedStories(x => x.IsFavorite == true);
            IsBusy = false;
        }

        [RelayCommand]
        public async Task RefreshFavoriteViewedStories()
        {
            IsRefreshing = true;
            Stories = await HistoryService.GetViewedStories(x => x.IsFavorite == true);
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
        }

        [RelayCommand]
        public async Task DeleteFromFavorites(string storyId)
        {
            var viewedStory = await ViewedStoryService.GetViewedStoryByStoryId(storyId);
            viewedStory.IsFavorite = false;
            await ViewedStoryService.UpdateViewedStory(viewedStory);
            var story = Stories.Where(x => x.StoryId == storyId).FirstOrDefault();
            Stories.Remove(story);
        }
    }
}
