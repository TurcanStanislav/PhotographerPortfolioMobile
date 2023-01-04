using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotographerPortfolioMobile.Services;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class QRScannerViewModel : ObservableObject
    {
        [ObservableProperty]
        private string videoUrl = "";
        private ScannerService _scannerService { get; set; }

        public QRScannerViewModel(ScannerService scannerService)
        {
            _scannerService = scannerService;
        }

        [RelayCommand]
        public async Task GetVideoByQRCode(string storyId)
        {
            VideoUrl = await _scannerService.GetVideoByQrCode(storyId);
        }
    }
}
