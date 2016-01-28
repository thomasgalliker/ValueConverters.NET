using System;
using System.Reflection;

namespace ValueConverters.Extensions
{
    internal static class ReflectionExtensions
    {
        public static Type[] GetGenericArguments(this Type type)
        {
            return type.GetTypeInfo().GenericTypeArguments;
        }

        public static MethodInfo GetMethod(this Type type, String methodName)
        {
            return type.GetTypeInfo().GetDeclaredMethod(methodName);
        }
    }
}