using CommunityToolkit.Mvvm.ComponentModel;
using PhotographerPortfolioMobile.Services.Interfaces;

namespace PhotographerPortfolioMobile.ViewModels
{
    [QueryProperty(nameof(VideoUrl), "VideoUrl")]
    public partial class VideoPlayerViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string videoUrl;

        [ObservableProperty]
        private int videoHeight = (int)double.Min(DeviceDisplay.Current.MainDisplayInfo.Height, DeviceDisplay.Current.MainDisplayInfo.Width) / 3;

        private IDeviceOrientationService DeviceOrientationService { get; }

        public VideoPlayerViewModel(IDeviceOrientationService deviceOrientationService)
        {
            DeviceOrientationService = deviceOrientationService;
            //DeviceOrientationService.SetDeviceOrientation(DisplayOrientation.Landscape);
        }
    }
}
