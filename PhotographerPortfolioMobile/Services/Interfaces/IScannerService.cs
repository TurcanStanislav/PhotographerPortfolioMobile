﻿using PhotographerPortfolioMobile.Models;

namespace PhotographerPortfolioMobile.Services.Interfaces
{
    public interface IScannerService
    {
        Task<QRScannerResponse> GetVideoUrlByQrCode(string storyId);
        Task<ImageScannerResponse> GetVideoUrlByImage(FileResult image);
    }
}
