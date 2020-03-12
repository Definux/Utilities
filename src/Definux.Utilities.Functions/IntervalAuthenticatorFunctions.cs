using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;

namespace Definux.Utilities.Functions
{
    public static class IntervalAuthenticatorFunctions
    {
        private const int IntervalLength = 30;
        private const int PinLength = 6;
        private static readonly int PinModulo = (int)Math.Pow(10, PinLength);
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private const string Base32AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        /// <summary>
        ///   Number of intervals that have elapsed.
        /// </summary>
        static long CurrentInterval
        {
            get
            {
                var ElapsedSeconds = (long)Math.Floor((DateTime.UtcNow - UnixEpoch).TotalSeconds);

                return ElapsedSeconds / IntervalLength;
            }
        }

        public static string GeneratePin(string key)
        {
            return GeneratePin(key.ToByteArray(), CurrentInterval);
        }

        private static string GeneratePin(byte[] key, long counter)
        {
            const int SizeOfInt32 = 4;

            var CounterBytes = BitConverter.GetBytes(counter);

            if (BitConverter.IsLittleEndian)
            {
                //spec requires bytes in big-endian order
                Array.Reverse(CounterBytes);
            }

            var Hash = new HMACSHA1(key).ComputeHash(CounterBytes);
            var Offset = Hash[Hash.Length - 1] & 0xF;

            var SelectedBytes = new byte[SizeOfInt32];
            Buffer.BlockCopy(Hash, Offset, SelectedBytes, 0, SizeOfInt32);

            if (BitConverter.IsLittleEndian)
            {
                //spec interprets bytes in big-endian order
                Array.Reverse(SelectedBytes);
            }

            var SelectedInteger = BitConverter.ToInt32(SelectedBytes, 0);

            //remove the most significant bit for interoperability per spec
            var TruncatedHash = SelectedInteger & 0x7FFFFFFF;

            //generate number of digits for given pin length
            var Pin = TruncatedHash % PinModulo;

            return Pin.ToString(CultureInfo.InvariantCulture).PadLeft(PinLength, '0');
        }

        public static byte[] ToByteArray(this string input)
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
