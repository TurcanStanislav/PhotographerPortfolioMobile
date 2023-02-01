using PhotographerPortfolioMobile.ViewModels;
using ZXing.Net.Maui;

namespace PhotographerPortfolioMobile.Views;

public partial class QRScannerPage : ContentPage
{
    private readonly QRScannerViewModel _viewModel;

    public QRScannerPage(QRScannerViewModel vm)
    {
        InitializeComponent();
        _viewModel = vm;
        BindingContext = vm;
    }
    protected override void OnAppearing()
    {
        _viewModel.IsScannerEnabled = true;
        barcodeReader.Options = new BarcodeReaderOptions
        {
            AutoRotate = true,
            Multiple = true
        };
        barcodeReader.CameraLocation = CameraLocation.Front;
        barcodeReader.CameraLocation = CameraLocation.Rear;
    }

    private async void OnBarcodeDetected(object sender, BarcodeDetectionEventArgs e)
    {
        await _viewModel.DisplayVideoByQRCodeCommand.ExecuteAsync(e.Results.FirstOrDefault().Value);
    }
}