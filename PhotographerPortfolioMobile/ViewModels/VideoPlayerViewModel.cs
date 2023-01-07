using CommunityToolkit.Mvvm.ComponentModel;

namespace PhotographerPortfolioMobile.ViewModels
{
    [QueryProperty(nameof(VideoUrl), "VideoUrl")]
    public partial class VideoPlayerViewModel : BaseViewModel
    {
        public VideoPlayerViewModel()
        {
        }

        [ObservableProperty]
        private string videoUrl;
    }
}
