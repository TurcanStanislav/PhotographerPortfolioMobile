using PhotographerPortfolioMobile.ViewModels;
using PhotographerPortfolioMobile.Views;

namespace PhotographerPortfolioMobile;

public partial class AppShell : Shell
{
    public AppShell(AppShellViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        Routing.RegisterRoute(nameof(AdsPage), typeof(AdsPage));
        Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
        Routing.RegisterRoute(nameof(VideoPlayerPage), typeof(VideoPlayerPage));
        Routing.RegisterRoute(nameof(AppSharingPage), typeof(AppSharingPage));
        Routing.RegisterRoute(nameof(QRScannerPage), typeof(QRScannerPage));
        Routing.RegisterRoute(nameof(ImageScannerPage), typeof(ImageScannerPage));
        Routing.RegisterRoute(nameof(StoryDetailsPage), typeof(StoryDetailsPage));
        Routing.RegisterRoute(nameof(FavoriteStoriesPage), typeof(FavoriteStoriesPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
    }
}
