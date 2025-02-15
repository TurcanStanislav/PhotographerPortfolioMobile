﻿using CommunityToolkit.Maui;
using PhotographerPortfolioMobile.Database;
using PhotographerPortfolioMobile.Repositories;
using PhotographerPortfolioMobile.Repositories.Interfaces;
using PhotographerPortfolioMobile.Services.DeviceOrientationService;
using PhotographerPortfolioMobile.Services.HistoryService;
using PhotographerPortfolioMobile.Services.Interfaces;
using PhotographerPortfolioMobile.Services.LocalStorageService;
using PhotographerPortfolioMobile.Services.ScannerService;
using PhotographerPortfolioMobile.Services.ViewedStoryService;
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
                fonts.AddFont("AccidentalPresidency.ttf", "AccidentalPresidency");
                fonts.AddFont("icons_webfont.ttf", "IconFontTypes");
            })
            .ConfigureMauiHandlers(h =>
            {
                h.AddHandler(typeof(CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler));
            });

        //Services
        builder.Services.AddTransient<HttpClient>();
        builder.Services.AddTransient<IHistoryService, HistoryService>();
        builder.Services.AddTransient<IScannerService, ScannerService>();
        builder.Services.AddTransient<IDeviceOrientationService, DeviceOrientationService>();
        builder.Services.AddTransient<IViewedStoryService, ViewedStoryService>();
        builder.Services.AddTransient<ILocalStorageService, LocalStorageService>();

        //Repositories
        builder.Services.AddTransient<IViewedStoryRepository, ViewedStoryRepository>();

        //ViewModels
        builder.Services.AddTransient<QRScannerViewModel>();
        builder.Services.AddTransient<VideoPlayerViewModel>();
        builder.Services.AddTransient<ImageScannerViewModel>();
        builder.Services.AddTransient<HistoryViewModel>();
        builder.Services.AddTransient<StoryDetailsViewModel>();
        builder.Services.AddTransient<FavoriteStoriesViewModel>();
        builder.Services.AddTransient<AppSharingViewModel>();
        builder.Services.AddTransient<AppShellViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<AdsViewModel>();

        //Pages
        builder.Services.AddTransient<QRScannerPage>();
        builder.Services.AddTransient<VideoPlayerPage>();
        builder.Services.AddTransient<ImageScannerPage>();
        builder.Services.AddTransient<HistoryPage>();
        builder.Services.AddTransient<StoryDetailsPage>();
        builder.Services.AddTransient<FavoriteStoriesPage>();
        builder.Services.AddTransient<AppSharingPage>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<AdsPage>();

        //Db
        builder.Services.AddTransient<AppDbContext>();

        return builder.Build();
    }
}
