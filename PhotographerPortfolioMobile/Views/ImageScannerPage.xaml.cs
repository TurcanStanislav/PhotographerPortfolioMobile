using PhotographerPortfolioMobile.Services.Interfaces;
using ZXing.Net.Maui;

namespace PhotographerPortfolioMobile.Views;

public partial class ImageScannerPage : ContentPage
{
    private IDeviceOrientationService _deviceOrientationService { get; }

    public ImageScannerPage(IDeviceOrientationService deviceOrientationService)
    {
        InitializeComponent();
        _deviceOrientationService = deviceOrientationService;
    }

    protected override async void OnAppearing()
    {
        imageScanner.CameraLocation = CameraLocation.Front;
        imageScanner.CameraLocation = CameraLocation.Rear;
    }

    public async void TakePhoto(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // save the file into local storage
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);
            }
        }
    }
}