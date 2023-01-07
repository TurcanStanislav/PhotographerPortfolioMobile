using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotographerPortfolioMobile.Services.Interfaces;
using PhotographerPortfolioMobile.Views;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class QRScannerViewModel : BaseViewModel
    {
        private IScannerService ScannerService { get; set; }

        [ObservableProperty]
        private string videoUrl;

        [ObservableProperty]
        private bool isDisplayVideoButtonEnabled;

        [ObservableProperty]
        private bool isScannerEnabled = true;

        public QRScannerViewModel(IScannerService scannerService)
        {
            ScannerService = scannerService;
        }

        [RelayCommand]
        private async Task GetVideoUrlByQRCode(string storyId)
        {
            VideoUrl = await ScannerService.GetVideoByQrCode(storyId);
            if (!string.IsNullOrEmpty(VideoUrl))
                IsDisplayVideoButtonEnabled = true;
            else
                IsDisplayVideoButtonEnabled = false;
        }

        [RelayCommand]
        private async Task DisplayVideoByUrl(string url)
        {
            IsScannerEnabled = false;
            if (!string.IsNullOrEmpty(url))
                await Shell.Current.GoToAsync(nameof(VideoPlayerPage), true, new Dictionary<string, object>
                {
                    { "VideoUrl", url }
                });
        }
    }
}
