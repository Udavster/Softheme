using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace try_26
{
    static class FileHelpers
    {
        public static void ReplaceOccurances(string path, string extension,
            string s, string r, ParallelLog log = null, int maxDegreeOfParallelism = 2)
        {
            List<string> fileNames = GetListOfFiles(path, extension);
            ParallelOptions options = new ParallelOptions();
            if (maxDegreeOfParallelism < 1)
            {
                throw new ArgumentException("Number of threads can't be " + maxDegreeOfParallelism);
            }
            Console.WriteLine("Invoking parallel");
            try
            {
                options.MaxDegreeOfParallelism = maxDegreeOfParallelism;
                Parallel.ForEach(fileNames, options, name => Replace(name, s, r, log));
                Console.WriteLine("Replaced");
            }
            catch (AggregateException exceptions)
            {
                Console.WriteLine(exceptions.Message);
                foreach (var exception in exceptions.Flatten().InnerExceptions)
                {
                    Console.WriteLine("\t{0}", exception.Message);
                }
            }
        }
        public static List<string> GetListOfFiles(string dirPath, string extension)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            return GetListOfFiles(new DirectoryInfo[] { dirInfo }, extension);
        }
        static List<string> GetListOfFiles(DirectoryInfo[] dicrectoryInfos, string extension)
        {
            List<string> fileNames = new List<string>();
            for (int i = 0; i < dicrectoryInfos.Length; i++)
            {
                FileInfo[] fileInfo = dicrectoryInfos[i].GetFiles("*." + extension);
                fileNames.AddRange(GetFileNameListFromFileInfoArray(fileInfo));
                DirectoryInfo[] innerDirInfos = dicrectoryInfos[i].GetDirectories();
                fileNames.AddRange(GetListOfFiles(innerDirInfos, extension));
            }
            return fileNames;
        }
        static List<string> GetFileNameListFromFileInfoArray(FileInfo[] fileInfos)
        {
            List<string> fileNames = new List<string>();
            for (int i = 0; i < fileInfos.Length; i++)
            {
                fileNames.Add(fileInfos[i].FullName);
            }
            return fileNames;
        }

        public static void Replace(string fileName, string s, string r,
            ParallelLog log = null)
        {
            if ((fileName == null) || (fileName == ""))
            {
                throw new ArgumentException("Empty filename is not allowed");
            }
            FileInfo fileInfo = new FileInfo(fileName);
            if (!fileInfo.Exists)
            {
                throw new ArgumentException("File doesn't exist");
            }

            string tempFileName = "./" + fileInfo.Name + ".tmp";
            using (var input = File.OpenText(fileName))
            {

                using (var output = new StreamWriter(tempFileName))
                {
                    string line;
                    int strNum = 0;
                    while (null != (line = input.ReadLine()))
                    {
                        string newLine = line.Replace(s, r);
                        if ((log != null) && (line != newLine))
                        {
                            log.Log(fileName, strNum, line, newLine);
                        }
                        output.WriteLine(newLine);
                        strNum++;
                    }
                }

            }
            File.Delete(fileInfo.FullName);
            File.Move(tempFileName, fileName);
        }
        public static bool CheckDirectoryExists(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            return dirInfo.Exists;
        }
    }
}
