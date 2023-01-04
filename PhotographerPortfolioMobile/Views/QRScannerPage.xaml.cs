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

        barcodeReader.Options = new BarcodeReaderOptions
        {
            AutoRotate = true,
            Multiple = true
        };
    }

    private async void OnBarcodeDetected(object sender, BarcodeDetectionEventArgs e)
    {
        await _viewModel.GetVideoByQRCode(e.Results.FirstOrDefault().Value);
    }
}