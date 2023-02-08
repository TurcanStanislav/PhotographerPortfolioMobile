using CommunityToolkit.Mvvm.Input;

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
                Uri = "https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/data-binding/basic-bindings?view=net-maui-7.0"
            });
        }
    }
}
