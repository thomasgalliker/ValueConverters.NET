namespace ValueConverters.Services
{
    internal class SystemTimeZoneInfo : ITimeZoneInfo
    {
        static readonly Lazy<ITimeZoneInfo> Implementation = new Lazy<ITimeZoneInfo>(CreateInstance, LazyThreadSafetyMode.PublicationOnly);

        public static ITimeZoneInfo Current => Implementation.Value;

        private static ITimeZoneInfo CreateInstance()
        {
            return new SystemTimeZoneInfo();
        }

        private SystemTimeZoneInfo()
        {
        }

        public TimeZoneInfo Utc => TimeZoneInfo.Utc;

        public TimeZoneInfo Local => TimeZoneInfo.Local;
    }
}
