using PhotographerPortfolioMobile.ViewModels;
using PhotographerPortfolioMobile.Views;

namespace PhotographerPortfolioMobile;

public partial class AppShell : Shell
{
    public AppShell(AppShellViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        Routing.RegisterRoute("watchedStories/details", typeof(StoryDetailsPage));
        Routing.RegisterRoute("favoriteStories/details", typeof(StoryDetailsPage));
        Routing.RegisterRoute("videoPlayer", typeof(VideoPlayerPage));
    }
}
