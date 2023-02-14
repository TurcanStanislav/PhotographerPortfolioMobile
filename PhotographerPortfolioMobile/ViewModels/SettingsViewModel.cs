using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotographerPortfolioMobile.Managers;
using PhotographerPortfolioMobile.Models;
using System.Globalization;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string selectedLanguage = availableLanguages[UserPreferences.CurrentCulture];

        private static Dictionary<string, string> availableLanguages = new Dictionary<string, string>
        {
            { "en-US", LocalizationResourceManager.Instance["en-US"].ToString() },
            { "ro-RO", LocalizationResourceManager.Instance["ro-RO"].ToString() },
            { "ru-RU", LocalizationResourceManager.Instance["ru-RU"].ToString() }
        };

        [ObservableProperty]
        private List<string> languageNames = availableLanguages.Values.ToList();

        //public LocalizationResourceManager LocalizationResourceManager
        //=> LocalizationResourceManager.Instance;

        public SettingsViewModel()
        {
        }

        [RelayCommand]
        public async Task ChangeLanguage(string languageName)
        {
            var cultureName = availableLanguages.FirstOrDefault(x => x.Value == languageName).Key;

            CultureInfo switchToCulture;
            bool selectedCultureExists = CultureInfo.GetCultures(CultureTypes.AllCultures)
                                                    .Any(culture => string.Equals(culture.Name, cultureName, StringComparison.CurrentCultureIgnoreCase));
            if (!string.IsNullOrWhiteSpace(cultureName) && selectedCultureExists)
                switchToCulture = new CultureInfo(cultureName);
            else
                switchToCulture = new CultureInfo("en-US");

            LocalizationResourceManager.Instance.SetCulture(switchToCulture);

            UserPreferences.CurrentCulture = switchToCulture.Name;

            CultureInfo.DefaultThreadCurrentCulture = switchToCulture;
            CultureInfo.DefaultThreadCurrentUICulture = switchToCulture;
        }
    }
}
