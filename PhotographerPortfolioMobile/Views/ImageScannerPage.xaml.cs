using PhotographerPortfolioMobile.ViewModels;

namespace PhotographerPortfolioMobile.Views;

public partial class ImageScannerPage : ContentPage
{
    private ImageScannerViewModel ViewModel { get; }

    public ImageScannerPage(ImageScannerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        ViewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

        if (photo != null)
            await ViewModel.GetVideoUrlByImageCommand.ExecuteAsync(photo);
        else await Shell.Current.GoToAsync(nameof(QRScannerPage));
    }

    //public async void TakePhoto(object sender, EventArgs e)
    //{
    //    if (MediaPicker.Default.IsCaptureSupported)
    //    {

    //        if (photo != null)
    //        {
    //            // save the file into local storage
    //            string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

    //            using Stream sourceStream = await photo.OpenReadAsync();
    //            using FileStream localFileStream = File.OpenWrite(localFilePath);

    //            await sourceStream.CopyToAsync(localFileStream);
    //        }
    //    }
    //}
}