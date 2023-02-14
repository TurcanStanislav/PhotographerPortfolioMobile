using PhotographerPortfolioMobile.Managers;
using PhotographerPortfolioMobile.Models;
using PhotographerPortfolioMobile.Resources.Styles;
using PhotographerPortfolioMobile.Resources.Themes;
using PhotographerPortfolioMobile.ViewModels;
using System.Globalization;

namespace PhotographerPortfolioMobile;

public partial class App : Application
{
    public App(AppShellViewModel appShelViewModel)
    {
        InitializeComponent();

        MainPage = new AppShell(appShelViewModel);
        LocalizationSetup();
        ThemeSetup();

    }

    private void LocalizationSetup()
    {
        LocalizationResourceManager.Instance.SetCulture(new CultureInfo(UserPreferences.CurrentCulture));
    }
    private void ThemeSetup()
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();
            if (UserPreferences.CurrentAppTheme.Equals(nameof(AppThemes.LightTheme)))
            {
                mergedDictionaries.Add(new LightTheme());
            }
            else
            {
                mergedDictionaries.Add(new DarkTheme());
            }

            mergedDictionaries.Add(new AppStyles());
        }
    }
}
