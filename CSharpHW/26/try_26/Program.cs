using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace try_26
{
    class Program
    {
        static void Main()
        {
            string logPath = "./log.txt";
            ParallelLog log;

            Console.WriteLine("Should I log? (y/*)");
            log = (Console.ReadLine().ToUpper() == "Y") ?
                new ParallelLog(logPath) : null;

            string dirName;
            do
            {
                Console.WriteLine("Enter directory name:");
                dirName = Console.ReadLine();
            } while (!FileHelpers.CheckDirectoryExists(dirName));

            Console.WriteLine("Enter extension of files that should be changed (without dot)" +
                " or * for all");
            string extension = Console.ReadLine();

            Console.WriteLine("Exter what to replace:");
            string origin = Console.ReadLine();

            Console.WriteLine("Exter replacement:");
            string replacement = Console.ReadLine();

            FileHelpers.ReplaceOccurances(dirName, extension, origin, replacement, log);

            if (log != null)
            {
                log.DumpToFile();
            }

            Console.WriteLine("You can read log here: {0}", logPath);
            Console.ReadLine();
        }


    }
}
