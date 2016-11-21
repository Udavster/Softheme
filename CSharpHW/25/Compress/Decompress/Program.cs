using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compress1;

namespace Decompress
{
    class Program
    {
        static void Main(string[] args)
        {
            //See another project in this solution for actual code
            Console.WriteLine("1Enter a path to directory");
            string path = Console.ReadLine();

            AnimateHelper.AnimateProgress(ZipHelpers.DecompressDirectoryContents(path));

            Console.WriteLine("\nReady");
            Console.ReadLine();
        }
    }
}
