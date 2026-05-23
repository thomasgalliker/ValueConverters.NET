using System.Reflection;

namespace ValueConverters.Extensions
{
    internal static class TypeExtensions
    {
        internal static bool IsNullable(this Type type)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}
