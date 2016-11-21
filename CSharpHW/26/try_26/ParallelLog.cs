using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace try_26
{
    class ParallelLog
    {
        private Dictionary<string, List<Tuple<int, string, string>>> cache;
        private string logFileName;
        public ParallelLog(string logFileName)
        {
            this.logFileName = logFileName;
            cache = new Dictionary<string, List<Tuple<int, string, string>>>();
        }
        public void Log(string fileName, int strNum, string oldStr, string newStr)
        {
            lock (this)
            {
                if (!cache.ContainsKey(fileName))
                {
                    cache.Add(fileName, new List<Tuple<int, string, string>>());
                }
                cache[fileName].Add(new Tuple<int, string, string>(strNum, oldStr, newStr));
            }
         }
        public void DumpToFile()
        {
            try
            {
                lock (this)
                {

                    using (var output = new StreamWriter(logFileName, true))
                    {
                        foreach (var item in cache)
                        {
                            output.WriteLine(item.Key);
                            var changedStringsList = item.Value;
                            foreach (var changedStringInfo in changedStringsList)
                            {
                                output.WriteLine(changedStringInfo.Item1 + ":");
                                output.WriteLine("\t" + changedStringInfo.Item2);
                                output.WriteLine("\t" + changedStringInfo.Item3);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string exceptionMessage = String.Format(
                    "Can't write to log file : {0}", ex.Message);
                Console.WriteLine(exceptionMessage);
            }
            this.cache = new Dictionary<string, List<Tuple<int, string, string>>>();

        }
        
    }
}
