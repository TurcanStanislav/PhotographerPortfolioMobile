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
        [ObservableProperty]
        private Story story;

        [ObservableProperty]
        private int storyImageWidth = 160;

        [ObservableProperty]
        private int storyImageHeight = 160;

        public StoryDetailsViewModel(IDeviceOrientationService deviceOrientationService)
        {
            DeviceOrientationService = deviceOrientationService;
        }

        private readonly IDeviceOrientationService DeviceOrientationService;

        [RelayCommand]
        public async Task DisplayVideoPlayer(ContentPage page)
        {
            if (string.IsNullOrEmpty(this.Story.VideoPath))
                return;

            var videoPlayerVM = new VideoPlayerViewModel(DeviceOrientationService) { VideoUrl = this.Story.VideoPath };
            await page.Navigation.PushAsync(new VideoPlayerPage(videoPlayerVM));
            //await page.Navigation.PushModalAsync(new VideoPlayerPage(videoPlayerVM));
            //await Shell.Current.GoToAsync(nameof(VideoPlayerPage), true, new Dictionary<string, object> {
            //    { "VideoUrl", this.Story.VideoPath }
            //});
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
