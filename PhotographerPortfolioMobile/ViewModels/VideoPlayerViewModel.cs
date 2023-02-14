using CommunityToolkit.Mvvm.ComponentModel;
using PhotographerPortfolioMobile.Services.Interfaces;

namespace PhotographerPortfolioMobile.ViewModels
{
    [QueryProperty(nameof(VideoUrl), "VideoUrl")]
    public partial class VideoPlayerViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string videoUrl;

        private readonly IDeviceOrientationService DeviceOrientationService;

        public VideoPlayerViewModel(IDeviceOrientationService deviceOrientationService)
        {
            DeviceOrientationService = deviceOrientationService;
            //DeviceOrientationService.SetDeviceOrientation(DisplayOrientation.Landscape);
        }
    }
}
