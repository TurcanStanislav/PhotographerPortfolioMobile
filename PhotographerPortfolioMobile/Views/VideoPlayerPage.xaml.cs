using PhotographerPortfolioMobile.ViewModels;
using System.Runtime.Versioning;

namespace PhotographerPortfolioMobile.Views;
public partial class VideoPlayerPage : ContentPage
{
    public VideoPlayerPage(VideoPlayerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    [RequiresPreviewFeatures] //TODO: To remove this later when I will upgrade to stable release version
    protected override void OnDisappearing()
    {
        videoPlayer.Stop();
        base.OnDisappearing();
    }
}