using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArray {
    class Program {
        static void Main(string[] args) {
            CustomArray<int> arrInt = new CustomArray<int>(0);
            arrInt.Verbose = true;
            arrInt.Add(1);
            arrInt.Add(2);
            arrInt.Add(3);
            Console.WriteLine("Does arrInt contain 2: {0}", arrInt.Contains(2).ToString());
            Console.WriteLine("Does arrInt contain 5: {0}", arrInt.Contains(5).ToString());
            Console.WriteLine("Length of array is {0}", arrInt.Length);
            Console.WriteLine();
            CustomArray<string> arrString = new CustomArray<string>(1, 3);
            arrString.Verbose = true;
            arrString.Add("Testing");
            arrString.Add("The");
            arrString.Add("Code");
            Console.WriteLine("Does string arrString contain Code: {0}", arrString.Contains("Code").ToString());
            Console.WriteLine("Does string arrString contain Sheep: {0}", arrString.Contains("Sheep").ToString());
            Console.ReadLine();
        }
    }
}
