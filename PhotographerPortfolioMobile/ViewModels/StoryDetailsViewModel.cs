using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Services.Interfaces;
using PhotographerPortfolioMobile.Views;

namespace PhotographerPortfolioMobile.ViewModels
{
    [QueryProperty(nameof(Story), "Story")]
    public partial class StoryDetailsViewModel : BaseViewModel
    {
        private readonly IDeviceOrientationService DeviceOrientationService;
        private readonly VideoPlayerViewModel VideoPlayerViewModel;

        [ObservableProperty]
        private Story story;

        [ObservableProperty]
        private int storyImageWidth = 160;

        [ObservableProperty]
        private int storyImageHeight = 160;

        public StoryDetailsViewModel(IDeviceOrientationService deviceOrientationService, VideoPlayerViewModel videoPlayerViewModel)
        {
            DeviceOrientationService = deviceOrientationService;
            VideoPlayerViewModel = videoPlayerViewModel;
        }

        [RelayCommand]
        public async Task DisplayVideoPlayer(ContentPage page)
        {
            if (string.IsNullOrEmpty(this.Story.VideoPath))
                return;

            var navParams = new Dictionary<string, object>
            {
                { "VideoUrl", this.Story.VideoPath }
            };
            await Shell.Current.GoToAsync("videoPlayer", true, navParams);
        }

        [RelayCommand]
        public async Task ShowImagePopup(ContentPage page)
        {
            var popup = new ImagePopup(this.Story.ImagePath);
            page.ShowPopup(popup);
            await Task.FromResult(false);
        }
    }
}
