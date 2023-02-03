using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Services.Interfaces;
using PhotographerPortfolioMobile.Views;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class QRScannerViewModel : BaseViewModel
    {
        private readonly IScannerService ScannerService;
        private readonly IViewedStoryService ViewedStoryService;

        [ObservableProperty]
        private string videoUrl;

        [ObservableProperty]
        private bool isScannerEnabled = true;

        public QRScannerViewModel(IScannerService scannerService, IViewedStoryService viewedStoryService)
        {
            ScannerService = scannerService;
            ViewedStoryService = viewedStoryService;
        }

        [RelayCommand]
        private async Task DisplayVideoByQRCode(string storyId)
        {
            IsScannerEnabled = false;
            var response = await ScannerService.GetVideoUrlByQrCode(storyId);

            if (response.Success == true)
            {
                await ViewedStoryService.SaveViewedStory(new ViewedStory { StoryId = response.StoryId, WatchedTime = DateTime.UtcNow });

                VideoUrl = string.Concat(Constants.BaseUrl, response.VideoUrl);
                if (!string.IsNullOrEmpty(VideoUrl))
                {
                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Shell.Current.GoToAsync(nameof(VideoPlayerPage), true, new Dictionary<string, object>
                        {
                            { "VideoUrl", VideoUrl }
                        });
                    });
                }
            }
            else
            {
                IsScannerEnabled = true;
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Shell.Current.DisplayAlert("Warning", response.ErrorMessage, "Ok");
                });
            }
        }
    }
}
