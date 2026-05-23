#if NETFRAMEWORK
namespace ValueConverters.Tests
{
    internal static class EnumCompat
    {
        public static TEnum[] GetValues<TEnum>()
            where TEnum : struct, global::System.Enum
        {
            return global::System.Linq.Enumerable.ToArray(
                global::System.Linq.Enumerable.Cast<TEnum>(
                    global::System.Enum.GetValues(typeof(TEnum))));
        }
    }
}
#endif
