using CommunityToolkit.Maui;
using CommunityToolkit.Maui.MediaElement;
using PhotographerPortfolioMobile.Services.DeviceOrientationService;
using PhotographerPortfolioMobile.Services.Interfaces;
using PhotographerPortfolioMobile.Services.ScannerService;
using PhotographerPortfolioMobile.ViewModels;
using PhotographerPortfolioMobile.Views;
using System.Runtime.Versioning;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace PhotographerPortfolioMobile;

public static class MauiProgram
{
    [RequiresPreviewFeatures]
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMediaElement() //TODO: To substitute this with a release nuget version
            .UseBarcodeReader()
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
        builder.Services.AddTransient<HttpClient>();
        builder.Services.AddTransient<IScannerService, ScannerService>();
        builder.Services.AddTransient<IDeviceOrientationService, DeviceOrientationService>();

        //ViewModels
        builder.Services.AddTransient<QRScannerViewModel>();
        builder.Services.AddTransient<QRScannerPage>();

        builder.Services.AddTransient<VideoPlayerViewModel>();
        builder.Services.AddTransient<VideoPlayerPage>();

        //Pages
        builder.Services.AddTransient<ImageScannerViewModel>();
        builder.Services.AddTransient<ImageScannerPage>();

        return builder.Build();
    }
}
