using System;

namespace ValueConverters.Extensions
{
    internal static class DateTimeExtensions
    {
        public static DateTime WithTimeZone(this DateTime dateTime, TimeZoneInfo targetTimeZone)
        {
            if (dateTime.Kind == DateTimeKind.Local)
            {
                return dateTime;
            }

            return TimeZoneInfo.ConvertTime(dateTime, targetTimeZone);
        }

        public static DateTimeOffset WithTimeZone(this DateTimeOffset dateTime, TimeZoneInfo targetTimeZone)
        {
            return TimeZoneInfo.ConvertTime(dateTime, targetTimeZone);
        }

        public static DateTime WithTimeZone(this DateTime? dateTime, TimeZoneInfo targetTimeZone)
        {
            return TimeZoneInfo.ConvertTime(dateTime!.Value, targetTimeZone);
        }
    }
}