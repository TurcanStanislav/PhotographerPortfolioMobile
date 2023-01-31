namespace PhotographerPortfolioMobile.Tools
{
    public static class ColorConverter
    {
        public static void ColorToHSL(Color color, out float hue, out float saturation, out float lightness)
        {
            float max = Math.Max(color.Red, Math.Max(color.Green, color.Blue));
            float min = Math.Min(color.Red, Math.Min(color.Green, color.Blue));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1f - (1f * min / max);
            lightness = (max + min) / 2f;
        }
    }
}
