using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotographerPortfolioMobile.Helpers;
using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Resources.Themes;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [ObservableProperty]
        private AppThemes appTheme = AppThemes.LightTheme;

        [ObservableProperty]
        private string changeThemeIconGlyph = IconFont.WeatherNight;

        public AppShellViewModel()
        {
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
                if (AppTheme == AppThemes.LightTheme)
                {
                    mergedDictionaries.Add(new DarkTheme());
                    AppTheme = AppThemes.DarkTheme;
                    ChangeThemeIconGlyph = IconFont.WeatherSunny;
                }
                else
                {
                    mergedDictionaries.Add(new LightTheme());
                    AppTheme = AppThemes.LightTheme;
                    ChangeThemeIconGlyph = IconFont.WeatherNight;
                }

            }
        }
    }
}
