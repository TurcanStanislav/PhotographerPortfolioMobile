using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotographerPortfolioMobile.Services.Interfaces;
using PhotographerPortfolioMobile.Views;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class ImageScannerViewModel : BaseViewModel
    {
        private IScannerService ScannerService { get; }

        [ObservableProperty]
        private string videoUrl;

        [ObservableProperty]
        private bool isScannerEnabled = true;

        public ImageScannerViewModel(IScannerService scannerService)
        {
            ScannerService = scannerService;
        }

        [RelayCommand]
        public async Task GetVideoUrlByImage(FileResult fileResult)
        {
            VideoUrl = await ScannerService.GetVideoUrlByImage(fileResult);

            if (!string.IsNullOrEmpty(VideoUrl))
            {
                IsScannerEnabled = false;
                if (MainThread.IsMainThread)
                {
                    await Shell.Current.GoToAsync(nameof(VideoPlayerPage), true, new Dictionary<string, object>
                    {
                        { "VideoUrl", VideoUrl }
                    });
                }
                else
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
        }
    }
}
