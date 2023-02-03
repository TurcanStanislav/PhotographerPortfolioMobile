using CommunityToolkit.Mvvm.ComponentModel;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class ImagePopupViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string imagePath;

        [ObservableProperty]
        private int deviceHeight;

        [ObservableProperty]
        private int deviceWidth = 400;

        public ImagePopupViewModel()
        {
            //DeviceHeight = (int)DeviceDisplay.MainDisplayInfo.Height;
            //DeviceWidth = (int)DeviceDisplay.MainDisplayInfo.Width;
        }
    }
}
