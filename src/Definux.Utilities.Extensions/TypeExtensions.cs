using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Definux.Utilities.Extensions
{
    /// <summary>
    /// Extensions for <see cref="Type"/>.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Check whether the <see cref="PropertyInfo"/> has the specified attribute.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static bool HasAttribute<T>(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes(typeof(T), true).Any();
        }

        /// <summary>
        /// Check whether the <see cref="MethodInfo"/> has the specified attribute.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        public static bool HasAttribute<T>(this MethodInfo methodInfo)
        {
            return methodInfo.GetCustomAttributes(typeof(T), true).Any();
        }

        /// <summary>
        /// Check whether the <see cref="Type"/> has the specified attribute.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool HasAttribute<T>(this Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).Any();
        }

        /// <summary>
        /// Check whether the underlying type is nullable type.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public static bool IsNullableType(this Type objectType)
        {
            return Nullable.GetUnderlyingType(objectType) != null;
        }

        /// <summary>
        /// Check whether the type is numeric type.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the specified attribute or default from current <see cref="PropertyInfo"/>.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this PropertyInfo propertyInfo)
        {
            if (propertyInfo.HasAttribute<T>())
            {
                return (T)propertyInfo.GetCustomAttributes(typeof(T), true).FirstOrDefault();
            }

            return default;
        }

        /// <summary>
        /// Gets the specified attribute or default from current <see cref="MethodInfo"/>.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this MethodInfo methodInfo)
        {
            if (methodInfo.HasAttribute<T>())
            {
                return (T)methodInfo.GetCustomAttributes(typeof(T), true).FirstOrDefault();
            }

            return default;
        }

        /// <summary>
        /// Gets the specified attribute or default from current <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Type type)
        {
            if (type.HasAttribute<T>())
            {
                return (T)type.GetCustomAttributes(typeof(T), true).FirstOrDefault();
            }

            return default;
        }

        /// <summary>
        /// Gets the <see cref="System.Net.Http.HttpMethod"/> from action from the controller based on action attributes.
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
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
