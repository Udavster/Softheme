using System;

namespace Compress1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a path to directory");
            string path = Console.ReadLine();

            AnimateHelper.AnimateProgress(ZipHelpers.CompressDirectoryContents(path));

            Console.WriteLine("\nReady");
            Console.ReadLine();
        }

    }
}