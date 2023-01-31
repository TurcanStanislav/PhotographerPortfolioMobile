using SkiaSharp;

namespace PhotographerPortfolioMobile.Tools
{
    public static class ImageConvertor
    {
        private const int NewSize = 524288;

        public static async Task<byte[]> ScaleImage(FileResult fileResult)
        {
            byte[] imageBytes;

            using (SKManagedStream stream = new SKManagedStream(await fileResult.OpenReadAsync()))
            {
                using (SKBitmap originalBitmap = SKBitmap.Decode(stream))
                {
                    float scale = (float)Math.Sqrt((float)NewSize / (originalBitmap.Width * originalBitmap.Height));
                    int width = (int)(originalBitmap.Width * scale);
                    int height = (int)(originalBitmap.Height * scale);
                    using (SKBitmap resizedBitmap = new SKBitmap(width, height))
                    {
                        originalBitmap.ScalePixels(resizedBitmap, SKFilterQuality.High);
                        using (SKImage image = SKImage.FromBitmap(resizedBitmap))
                        {
                            using (SKData data = image.Encode(SKEncodedImageFormat.Png, 100))
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    data.SaveTo(memoryStream);
                                    imageBytes = memoryStream.ToArray();
                                }
                            }
                        }
                    }
                }
            }

            return imageBytes;
        }
    }
}
