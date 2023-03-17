using PhotographerPortfolioMobile.Converters.Models;
using System.Globalization;

namespace PhotographerPortfolioMobile.Converters
{
    public class ImagePopupParametersConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new ImagePopupParameters
            {
                Page = (ContentPage)values[0],
                ImageUrl = (string)values[1]
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
