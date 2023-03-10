using PhotographerPortfolioMobile.Views;

namespace PhotographerPortfolioMobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AdsPage), typeof(AdsPage));
		Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
		Routing.RegisterRoute(nameof(VideoPlayerPage), typeof(VideoPlayerPage));
		Routing.RegisterRoute(nameof(AppSharingPage), typeof(AppSharingPage));
		Routing.RegisterRoute(nameof(QRScannerPage), typeof(QRScannerPage));
		Routing.RegisterRoute(nameof(ImageScannerPage), typeof(ImageScannerPage));
	}
}
