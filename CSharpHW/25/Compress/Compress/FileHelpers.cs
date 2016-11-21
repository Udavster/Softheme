using System.Collections.Generic;
using System.IO;

namespace Compress1
{
    public static class FileHelpers
    {
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

        public static bool CheckDirectoryExists(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            return dirInfo.Exists;
        }
    }
}
