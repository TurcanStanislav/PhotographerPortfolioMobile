using SkiaSharp;
using System.Text;

namespace PhotographerPortfolioMobile.Tools
{
    public static class ImageHashGenerator
    {
        private static void ConvertToGrayscale(this SKBitmap originalBitmap)
        {
            for (int y = 0; y < originalBitmap.Height; y++)
            {
                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    var pixel = originalBitmap.GetPixel(x, y);
                    int gray = (int)(0.299 * pixel.Red + 0.587 * pixel.Green + 0.114 * pixel.Blue);
                    ColorConverter.ColorToHSL(new Color(gray, gray, gray), out float h, out float s, out float l);
                    originalBitmap.SetPixel(x, y, SKColor.FromHsl(h, s, l));
                }
            }
        }

        private static double[,] GetDCTMatrix(SKBitmap bitmap)
        {
            double pi = Math.PI;
            int i, j, k, l;
            int width = bitmap.Width, height = bitmap.Height;

            double[,] dct = new double[width, height];
            double ci, cj, dct1, sum;

            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    if (i == 0)
                        ci = 1 / Math.Sqrt(width);
                    else
                        ci = Math.Sqrt(2) / Math.Sqrt(width);
                    if (j == 0)
                        cj = 1 / Math.Sqrt(height);
                    else
                        cj = Math.Sqrt(2) / Math.Sqrt(height);

                    sum = 0;
                    for (k = 0; k < width; k++)
                    {
                        for (l = 0; l < height; l++)
                        {
                            dct1 = bitmap.GetPixel(k, l).Red *
                              Math.Cos((2 * k + 1) * i * pi / (2 * width)) *
                              Math.Cos((2 * l + 1) * j * pi / (2 * height));
                            sum = sum + dct1;
                        }
                    }
                    dct[i, j] = ci * cj * sum;
                }
            }

            return dct;
        }

        public static double GetHammingDistanceCoefficient(string s1, string s2)
        {
            int difference = 0; double similarity = 0;
            if (s1.Length != s2.Length)
                similarity = 0;
            else
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] != s2[i])
                    {
                        difference++;
                    }
                }

                similarity = (s1.Length - difference) / (double)s1.Length;
            }

            return similarity;
        }

        public static async Task<string> GetHashForImageUsingPHash(FileResult image)
        {
            using var imgStream = await image.OpenReadAsync();

            var originalBitmap = SKBitmap.Decode(imgStream);

            // Resize the image
            SKBitmap resizedBitmap = originalBitmap.Resize(new SKImageInfo(32, 32), SKFilterQuality.High);

            // Convert the image to grayscale
            using (SKBitmap grayscale = new SKBitmap(resizedBitmap.Width, resizedBitmap.Height, SKColorType.Gray8, SKAlphaType.Opaque))
            {
                using (SKCanvas canvas = new SKCanvas(grayscale))
                {
                    canvas.DrawBitmap(resizedBitmap, 0, 0);
                }

                // Calculate the DCT
                double[,] dct = GetDCTMatrix(grayscale);

                // Get the 8x8 block in the top-left corner
                double[,] dctBlock = new double[8, 8];
                Array.Copy(dct, dctBlock, 64);

                // Average the values
                double average = dctBlock.Cast<double>().Average();

                // Create the hash
                byte[] hash = new byte[64];
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (dctBlock[x, y] > average)
                        {
                            hash[x + y * 8] = 1;
                        }
                    }
                }

                // Return the hash as a string
                return string.Join("", hash.Select(b => b.ToString()));
            }
        }

        public static async Task<string> GetHashForImageUsingDHash(FileResult image)
        {
            using var imgStream = await image.OpenReadAsync();

            var imgBitmap = SKBitmap.Decode(imgStream);
            var resizedBitmap = imgBitmap.Resize(new SKImageInfo(9, 8), SKFilterQuality.High);

            resizedBitmap.ConvertToGrayscale();

            StringBuilder hash = new StringBuilder();
            for (int y = 0; y < resizedBitmap.Height; y++)
            {
                for (int x = 0; x < resizedBitmap.Width - 1; x++)
                {
                    var leftPixel = resizedBitmap.GetPixel(x, y);
                    var rightPixel = resizedBitmap.GetPixel(x + 1, y);
                    int difference = leftPixel.Red - rightPixel.Red;
                    hash.Append(difference >= 0 ? "1" : "0");
                }
            }

            for (int x = 0; x < resizedBitmap.Width; x++)
            {
                for (int y = 0; y < resizedBitmap.Height - 1; y++)
                {
                    var upperPixel = resizedBitmap.GetPixel(x, y);
                    var lowerPixel = resizedBitmap.GetPixel(x, y + 1);
                    int difference = upperPixel.Red - lowerPixel.Red;
                    hash.Append(difference >= 0 ? "1" : "0");
                }
            }

            return hash.ToString();
        }
    }
}
