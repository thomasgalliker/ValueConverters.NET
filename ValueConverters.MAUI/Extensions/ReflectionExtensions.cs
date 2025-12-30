using System.Reflection;

namespace ValueConverters.Extensions
{
    internal static class ReflectionExtensions
    {
        public static Type[] GetGenericArguments(this Type type)
        {
            return type.GetTypeInfo().GenericTypeArguments;
        }

        public static MethodInfo? GetMethod(this Type type, string methodName)
        {
            return type.GetTypeInfo().GetMethod(methodName);
        }

        public static MethodInfo? GetMethod(this TypeInfo type, string methodName)
        {
            return type.GetDeclaredMethod(methodName);
        }
    }
}