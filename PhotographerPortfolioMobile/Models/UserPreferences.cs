namespace PhotographerPortfolioMobile.Models
{
    public static class UserPreferences
    {
        public static string CurrentCulture
        {
            get => Preferences.Default.Get(nameof(UserPreferences.CurrentCulture), "en-US");
            set => Preferences.Default.Set(nameof(UserPreferences.CurrentCulture), value);
        }

        public static string CurrentAppTheme
        {
            get => Preferences.Default.Get(nameof(UserPreferences.CurrentAppTheme), nameof(AppThemes.LightTheme));
            set => Preferences.Default.Set(nameof(UserPreferences.CurrentAppTheme), value);
        }
    }
}
