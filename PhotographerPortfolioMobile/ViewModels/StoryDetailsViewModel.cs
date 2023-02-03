using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Views;

namespace PhotographerPortfolioMobile.ViewModels
{
    [QueryProperty(nameof(Story), "Story")]
    public partial class StoryDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Story story;

        [ObservableProperty]
        private int storyImageWidth = 160;

        [ObservableProperty]
        private int storyImageHeight = 160;

        public StoryDetailsViewModel()
        {
            Title = "Story Details";
        }

        [RelayCommand]
        public async Task DisplayVideoPlayer(string videoPath)
        {
            if (string.IsNullOrEmpty(videoPath))
                return;

            await Shell.Current.GoToAsync(nameof(VideoPlayerPage), true, new Dictionary<string, object> {
                { "VideoUrl", videoPath }
            });
        }

        [RelayCommand]
        public async Task ShowImagePopup(ContentPage page)
        {
            var popup = new ImagePopup(Story.ImagePath);
            page.ShowPopup(popup);
        }
    }
}
