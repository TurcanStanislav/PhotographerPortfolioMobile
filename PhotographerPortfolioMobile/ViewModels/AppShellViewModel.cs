using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotographerPortfolioMobile.Helpers;
using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Resources.Styles;
using PhotographerPortfolioMobile.Resources.Themes;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string changeThemeIconGlyph;

        public AppShellViewModel()
        {
            ChangeThemeIconGlyph = UserPreferences.CurrentAppTheme == nameof(AppThemes.LightTheme) ? IconFont.WeatherNight : IconFont.WeatherSunny;
        }

        [RelayCommand]
        public async Task ChangeCurrentAppTheme(ImageButton themeImageButton)
        {
            await themeImageButton.ScaleTo(1.5, 300, Easing.CubicIn);
            await themeImageButton.ScaleTo(1, 150, Easing.CubicOut);

            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                if (UserPreferences.CurrentAppTheme == nameof(AppThemes.LightTheme))
                {
                    mergedDictionaries.Add(new DarkTheme());
                    UserPreferences.CurrentAppTheme = nameof(AppThemes.DarkTheme);
                    ChangeThemeIconGlyph = IconFont.WeatherSunny;
                }
                else
                {
                    mergedDictionaries.Add(new LightTheme());
                    UserPreferences.CurrentAppTheme = nameof(AppThemes.LightTheme);
                    ChangeThemeIconGlyph = IconFont.WeatherNight;
                }

                mergedDictionaries.Add(new AppStyles());
            }
        }
    }
}
