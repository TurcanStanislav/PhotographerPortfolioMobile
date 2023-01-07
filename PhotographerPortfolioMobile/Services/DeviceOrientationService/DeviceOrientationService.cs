using PhotographerPortfolioMobile.Services.Interfaces;

#if ANDROID
using Android.Content.PM;
#elif IOS
using UIKit;
#endif

namespace PhotographerPortfolioMobile.Services.DeviceOrientationService
{
    public class DeviceOrientationService : IDeviceOrientationService
    {
#if ANDROID
        private static readonly IReadOnlyDictionary<DisplayOrientation, ScreenOrientation> _androidDisplayOrientationMap =
            new Dictionary<DisplayOrientation, ScreenOrientation>
            {
                [DisplayOrientation.Landscape] = ScreenOrientation.Landscape,
                [DisplayOrientation.Portrait] = ScreenOrientation.Portrait,
            };
#elif IOS
        private static readonly IReadOnlyDictionary<DisplayOrientation, UIInterfaceOrientation> _iosDisplayOrientationMap =
            new Dictionary<DisplayOrientation, UIInterfaceOrientation>
            {
                [DisplayOrientation.Landscape] = UIInterfaceOrientation.LandscapeLeft,
                [DisplayOrientation.Portrait] = UIInterfaceOrientation.Portrait,
            };
#endif

        public void SetDeviceOrientation(DisplayOrientation displayOrientation)
        {
#if ANDROID
            var currentActivity = ActivityStateManager.Default.GetCurrentActivity();
            if (currentActivity is not null)
            {
                if (_androidDisplayOrientationMap.TryGetValue(displayOrientation, out ScreenOrientation screenOrientation))
                    currentActivity.RequestedOrientation = screenOrientation;
            }
#elif IOS
            if (_iosDisplayOrientationMap.TryGetValue(displayOrientation, out var iosOrientation))
                UIApplication.SharedApplication.SetStatusBarOrientation(iosOrientation, true);
#endif
        }
    }
}
