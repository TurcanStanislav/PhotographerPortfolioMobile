using CommunityToolkit.Mvvm.ComponentModel;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class ImagePopupViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string imagePath;

        [ObservableProperty]
        private int popupSize = 400;

        public ImagePopupViewModel()
        {
        }
    }
}
