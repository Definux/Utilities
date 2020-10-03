using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;

namespace Definux.Utilities.Functions
{
    /// <summary>
    /// Interval authenticator functions.
    /// </summary>
    public static class IntervalAuthenticatorFunctions
    {
        private const string Base32AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        private const int IntervalLength = 30;
        private const int PinLength = 6;
        private static readonly int PinModulo = (int)Math.Pow(10, PinLength);
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Number of intervals that have elapsed.
        /// </summary>
        internal static long CurrentInterval
        {
            get
            {
                var elapsedSeconds = (long)Math.Floor((DateTime.UtcNow - UnixEpoch).TotalSeconds);

                return elapsedSeconds / IntervalLength;
            }
        }

        /// <summary>
        /// Generate pin code from authenticator key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GeneratePin(string key)
        {
            return GeneratePin(key.ToByteArray(), CurrentInterval);
        }

        private static string GeneratePin(byte[] key, long counter)
        {
            const int SizeOfInt32 = 4;

            var counterBytes = BitConverter.GetBytes(counter);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(counterBytes);
            }

            var hash = new HMACSHA1(key).ComputeHash(counterBytes);
            var offset = hash[hash.Length - 1] & 0xF;

            var selectedBytes = new byte[SizeOfInt32];
            Buffer.BlockCopy(hash, offset, selectedBytes, 0, SizeOfInt32);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(selectedBytes);
            }

            var selectedInteger = BitConverter.ToInt32(selectedBytes, 0);
            var truncatedHash = selectedInteger & 0x7FFFFFFF;
            var pin = truncatedHash % PinModulo;

            return pin.ToString(CultureInfo.InvariantCulture).PadLeft(PinLength, '0');
        }

        private static byte[] ToByteArray(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new byte[0];
            }

            var bits = input.TrimEnd('=').ToUpper().ToCharArray().Select(c => Convert.ToString(Base32AllowedCharacters.IndexOf(c), 2).PadLeft(5, '0')).Aggregate((a, b) => a + b);
            var result = Enumerable.Range(0, bits.Length / 8).Select(i => Convert.ToByte(bits.Substring(i * 8, 8), 2)).ToArray();
            return result;
        }
    }
}
