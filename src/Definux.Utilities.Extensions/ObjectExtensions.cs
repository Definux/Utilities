using System;

namespace Definux.Utilities.Extensions
{
    /// <summary>
    /// Extensions for <see cref="object"/>.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Get GUID value or null from object value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid GetGuidValueOrDefault(this object value)
        {
            var resultGuid = Guid.Empty;
            if (value != null)
            {
                Guid.TryParse(value.ToString(), out resultGuid);
            }

            return resultGuid;
        }
    }
}
