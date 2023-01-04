using PhotographerPortfolioMobile.Services;
using PhotographerPortfolioMobile.ViewModels;
using PhotographerPortfolioMobile.Views;
using ZXing.Net.Maui;

namespace PhotographerPortfolioMobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<QRScannerViewModel>();
        builder.Services.AddSingleton<ScannerService>();
        builder.Services.AddSingleton<QRScannerPage>();

        return builder.Build();
    }
}
