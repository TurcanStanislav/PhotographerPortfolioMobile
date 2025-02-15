using PhotographerPortfolioMobile.ViewModels;

namespace PhotographerPortfolioMobile.Views;

public partial class ImageScannerPage : ContentPage
{
    private ImageScannerViewModel ImageScannerViewModel { get; }

    public ImageScannerPage(ImageScannerViewModel imageScannerViewModel)
    {
        InitializeComponent();
        BindingContext = imageScannerViewModel;
        ImageScannerViewModel = imageScannerViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        do
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
                await ImageScannerViewModel.GetVideoUrlByImageCommand.ExecuteAsync(photo);
            else
                break;
        } while (string.IsNullOrEmpty(ImageScannerViewModel.VideoUrl));
    }
}