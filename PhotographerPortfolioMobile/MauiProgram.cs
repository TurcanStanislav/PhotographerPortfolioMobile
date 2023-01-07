using CommunityToolkit.Maui;
using PhotographerPortfolioMobile.Services.DeviceOrientationService;
using PhotographerPortfolioMobile.Services.Interfaces;
using PhotographerPortfolioMobile.Services.ScannerService;
using PhotographerPortfolioMobile.ViewModels;
using PhotographerPortfolioMobile.Views;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace PhotographerPortfolioMobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .ConfigureMauiHandlers(h =>
            {
                h.AddHandler(typeof(CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler));
            });

        //Services
        builder.Services.AddTransient<IScannerService, ScannerService>();
        builder.Services.AddTransient<IDeviceOrientationService, DeviceOrientationService>();

        //ViewModels
        builder.Services.AddTransient<QRScannerViewModel>();
        builder.Services.AddTransient<QRScannerPage>();

        builder.Services.AddTransient<VideoPlayerViewModel>();
        builder.Services.AddTransient<VideoPlayerPage>();

        //Pages
        builder.Services.AddSingleton<ImageScannerPage>();

        return builder.Build();
    }
}
