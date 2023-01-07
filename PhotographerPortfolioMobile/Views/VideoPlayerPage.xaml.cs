using PhotographerPortfolioMobile.ViewModels;

namespace PhotographerPortfolioMobile.Views;
public partial class VideoPlayerPage : ContentPage
{
    public VideoPlayerPage(VideoPlayerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}