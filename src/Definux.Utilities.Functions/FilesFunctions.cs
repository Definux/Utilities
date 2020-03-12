using Definux.Utilities.Enumerations;
using System;

namespace Definux.Utilities.Functions
{
    public static class FilesFunctions
    {
        private static readonly string[] SizeSuffixes =
           { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }
            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

        public static string GetUniqueFileName()
        {
            return $"f{CryptoFunctions.MD5Hash(Guid.NewGuid().ToString()).ToLower()}{Guid.NewGuid().ToString().ToLower().Replace("-", string.Empty)}";
        }

        public static FileExtensions GetFileExtension(string extension)
        {
            string enumStandardExtension = $"_{extension.Replace(".", string.Empty)}";
            FileExtensions result = (FileExtensions)(Enum.Parse(typeof(FileExtensions), enumStandardExtension, true));
            return result;
        }

        public static FileTypes GetFileType(FileExtensions fileExtension)
        {
            int fileExtensionCode = (int)fileExtension;

            int fileTypeCode = ((int)((double)fileExtensionCode / 100)) - 9;

            return (FileTypes)fileTypeCode;
        }
    }
}
