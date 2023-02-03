namespace PhotographerPortfolioMobile.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ConvertToUtc(this DateTime dateTimeTimeZoneSpecific)
        {
            return TimeZoneInfo.ConvertTimeToUtc(dateTimeTimeZoneSpecific);
        }

        public static DateTime ConvertToTimeZone(this DateTime dateTimeUtc)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, TimeZoneInfo.Local);
        }
    }
}
