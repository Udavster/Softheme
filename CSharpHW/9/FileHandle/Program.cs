using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandle {
    class Program {
        static void Main(string[] args) {
            FileHandle fileHandle = 
                FileHandle.OpenFile(fileName:"somefile.txt",
                filePath: "C:\\Users\\",
                fileAccess: FileHandle.FileAccessEnum.Read|FileHandle.FileAccessEnum.Write);
            Console.WriteLine(fileHandle.ToString());
            FileHandle readH = FileHandle.OpenForRead("book.txt", "C:\\");
            Console.WriteLine(readH.ToString());
            FileHandle writeH = FileHandle.OpenForWrite("somecode.cs", "C:\\");
            Console.WriteLine(writeH.ToString());
            FileHandle demo = FileHandle.OpenForRead("demo.txt", "C:\\").OpenForWrite();
            Console.WriteLine(demo.ToString());
            fileHandle.Close();
            readH.Close();
            writeH.Close();
            demo.Close();
            Console.ReadLine();
            
        }
    }

    struct FileHandle {
        private string FileName;
        private string FilePath;
        public FileAccessEnum FileAccess { get; private set; }

        //Calling default constructor because before c#6 auto properties
        //can't be used in structs without it.
        public FileHandle(string fileName, string filePath, FileAccessEnum fileAccess ):this() {
            FileName = fileName;
            FilePath = filePath;
            FileAccess = fileAccess;
        }
        
        [Flags]
        public enum FileAccessEnum:byte {
            Read = 1,
            Write = 2
        }
        public static FileHandle OpenForRead(string fileName, string filePath) {
            return new FileHandle(fileName, filePath, FileAccessEnum.Read);
        }
        public static FileHandle OpenForWrite(string fileName, string filePath) {
            return new FileHandle(fileName, filePath, FileAccessEnum.Write);
        }
        public static FileHandle OpenFile(string fileName, string filePath, FileAccessEnum fileAccess) {
            return new FileHandle(fileName, filePath, fileAccess);
        }
        //For already opened file - add another access modifier:
        public FileHandle OpenForWrite() {
            this.FileAccess = this.FileAccess | FileAccessEnum.Write;
            return this;
        }
        public FileHandle OpenForRead() {
            this.FileAccess = this.FileAccess | FileAccessEnum.Read;
            return this;
        }
        public override string ToString() {
            return String.Format("File \"{0}\\{1}\" opened for: {2}", FilePath, FileName, FileAccess.ToString());
        }
        public void Close() {
            FileAccess = (FileAccessEnum)0;
        }
    }
}
