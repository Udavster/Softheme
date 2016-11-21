using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.IO.Compression;


namespace Compress1
{
    public class ZipHelpers
    {
        public static bool ErrorOccured { get; private set; }

        static Thread ProcessDirectoryContents(string path, bool decompress = false)
        {
            if (!FileHelpers.CheckDirectoryExists(path))
            {
                string excMessage = String.Format("({0}) directory doesn't exist", path);
                throw new ArgumentException(excMessage);
            }

            List<string> fileNames = FileHelpers.GetListOfFiles(path, "*");
            Thread anotherThread;

            if (decompress)
            {
                anotherThread = new Thread(
                    new ThreadStart(() => DecompressFiles(fileNames))
                );
            }
            else
            {
                anotherThread = new Thread(
                    new ThreadStart(() => CompressFiles(fileNames))
                );
            }
            anotherThread.Start();

            return anotherThread;
        }

        public static Thread CompressDirectoryContents(string path)
        {
            return ProcessDirectoryContents(path, false);
        }

        public static Thread DecompressDirectoryContents(string path)
        {
            return ProcessDirectoryContents(path, true);
        }

        static void CompressFiles(List<string> fileNames)
        {
            try
            {
                foreach (var fileName in fileNames)
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    if (fileInfo.Extension == ".zip")
                    {
                        continue;
                    }

                    if (!fileInfo.Exists)
                    {
                        throw new Exception("Contents of folder changed while processing");
                    }

                    using (FileStream fs = new FileStream(fileInfo.FullName + ".zip", FileMode.Create))
                    {
                        using (ZipArchive arch = new ZipArchive(fs, ZipArchiveMode.Create))
                        {
                            arch.CreateEntryFromFile(fileInfo.FullName, fileInfo.Name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to complete:");
                Console.WriteLine(ex.Message);
                ErrorOccured = true;
            }
        }

        static void DecompressFiles(List<string> fileNames)
        {
            try
            {
                foreach (var fileName in fileNames)
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    if (fileInfo.Extension != ".zip")
                    {
                        continue;
                    }

                    if (!fileInfo.Exists)
                    {
                        throw new Exception("Contents of folder changed while processing");
                    }

                    using (ZipArchive archive = ZipFile.Open(fileInfo.FullName, ZipArchiveMode.Update))
                    {
                        archive.ExtractToDirectory(fileInfo.DirectoryName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to complete:");
                Console.WriteLine(ex.Message);
                ErrorOccured = true;
            }
        }
    }
}