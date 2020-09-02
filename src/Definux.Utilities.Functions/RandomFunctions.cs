using System;
using System.IO;

namespace Definux.Utilities.Functions
{
    public static class RandomFunctions
    {
        private static Random Random = new Random();

        public static T GetRandomElementFromArray<T>(T[] array)
        {
            return array[Random.Next(0, array.Length)];
        }

        public static string GetRandomFileFromDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                var files = Directory.GetFiles(directory);
                if (files != null && files.Length > 0)
                {
                    return GetRandomElementFromArray(files);
                }
            }

            return null;
        }
    }
}
