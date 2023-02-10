using CommunityToolkit.Mvvm.Input;
using PhotographerPortfolioMobile.Models;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class AppSharingViewModel : BaseViewModel
    {
        public AppSharingViewModel()
        {

        }

        [RelayCommand]
        public async Task ShareApp(string message)
        {
            await Share.Default.RequestAsync(new ShareTextRequest
            {
                Title = "App Sharing",
                Text = message,
                Uri = Constants.BaseUrl
            });
        }
    }
}
