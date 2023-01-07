using CommunityToolkit.Mvvm.ComponentModel;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;
    }
}
