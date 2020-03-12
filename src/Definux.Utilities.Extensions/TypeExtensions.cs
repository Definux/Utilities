using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;

namespace Definux.Utilities.Extensions
{
    public static class TypeExtensions
    {
        public static bool HasAttribute<T>(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes(typeof(T), true).Any();
        }

        public static bool HasAttribute<T>(this MethodInfo methodInfo)
        {
            return methodInfo.GetCustomAttributes(typeof(T), true).Any();
        }

        public static bool HasAttribute<T>(this Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).Any();
        }

        public static bool IsNullableType(this Type objectType)
        {
            return Nullable.GetUnderlyingType(objectType) != null;
        }

        public static bool IsNumericType(this Type objectType)
        {
            switch (Type.GetTypeCode(objectType))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static T GetAttribute<T>(this PropertyInfo propertyInfo)
        {
            if (propertyInfo.HasAttribute<T>())
            {
                return ((T)propertyInfo.GetCustomAttributes(typeof(T), true).FirstOrDefault());
            }

            return default(T);
        }

        public static T GetAttribute<T>(this MethodInfo methodInfo)
        {
            if (methodInfo.HasAttribute<T>())
            {
                return ((T)methodInfo.GetCustomAttributes(typeof(T), true).FirstOrDefault());
            }

            return default(T);
        }

        public static T GetAttribute<T>(this Type type)
        {
            if (type.HasAttribute<T>())
            {
                return ((T)type.GetCustomAttributes(typeof(T), true).FirstOrDefault());
            }

            return default(T);
        }

        public static System.Net.Http.HttpMethod GetControllerActionHttpMethod(this MethodInfo methodInfo)
        {
            System.Net.Http.HttpMethod resultMethod = System.Net.Http.HttpMethod.Get;

            if (methodInfo.HasAttribute<HttpGetAttribute>())
            {
                resultMethod = System.Net.Http.HttpMethod.Get;
            }
            else if (methodInfo.HasAttribute<HttpPostAttribute>())
            {
                resultMethod = System.Net.Http.HttpMethod.Post;
            }
            else if (methodInfo.HasAttribute<HttpPutAttribute>())
            {
                resultMethod = System.Net.Http.HttpMethod.Put;
            }
            else if (methodInfo.HasAttribute<HttpDeleteAttribute>())
            {
                resultMethod = System.Net.Http.HttpMethod.Delete;
            }

            return resultMethod;
        }
    }
}
