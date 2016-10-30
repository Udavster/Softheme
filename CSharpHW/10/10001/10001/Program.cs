using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10001 {
    class Program {
        static void Main(string[] args) {
            int[] arr = Generate(10001, 0, 10);
            Console.WriteLine(OddElement(arr));
            Console.ReadLine();
        }

        static int[] Generate(UInt16 length, int minValue, int maxValue) {
            int[] arr = new int[length];
            Random random = new Random();
            if (length % 2 == 0) throw new Exception("");
            if (length == 0) return new int[0];
            if (minValue >= maxValue) throw new Exception("");

            for (int i = 0; i < length / 2; i++)
            {
                arr[i] = random.Next(minValue, maxValue + 1);
                arr[length - 1 - i] = arr[i];
            }
            arr[length/2] = random.Next(minValue, maxValue + 1);
            for (int i = 0; i < length; i++) {
                int exchangeNum = random.Next(0, length - 1);
                int temp = arr[i];
                arr[i] = arr[exchangeNum];
                arr[exchangeNum] = temp;
            }
            return arr;
        }

        static int OddElement(int[] arr)
        {
            if(arr.Length%2==0) throw new Exception();
            int result = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                result ^= arr[i];
            }
            return result;
        }
    }
}
