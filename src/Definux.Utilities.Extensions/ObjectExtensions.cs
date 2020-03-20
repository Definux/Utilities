using System;
using System.Collections.Generic;
using System.Text;

namespace Definux.Utilities.Extensions
{
    public static class ObjectExtensions
    {
        public static Guid GetGuidValueOrDefault(this object value)
        {
            Guid resultGuid = Guid.Empty;
            if (value != null)
            {
                Guid.TryParse(value.ToString(), out resultGuid);
            }

            return resultGuid;
        }
    }
}
