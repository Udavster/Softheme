using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort {
    class Program {
        static void Main(string[] args) {
            int[] arr = new int[] { 1, 3, 3, 34, 23, 5, 127, 8, 83, -1, 8, 23, 1, 4, -21, 0 };
            Console.WriteLine("Before sort:");
            for (int i = 0; i < arr.Length; i++) {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
            Console.WriteLine("After sort:");
            MergeSort(arr);
            for (int i = 0; i < arr.Length; i++) {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        public static void MergeSort(int[] array) {
            MergeSort(array, 0, array.Length - 1);
        }
        private static void MergeSort(int[] array, int left, int right) {
            int middle;
            if (left < right) {
                middle = (left + right) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);

                Merge(array, left, middle + 1, right);
            }
        }
        private static void Merge(int[] array, int left, int middle, int right) {
            int length = right - left + 1;
            int[] temp = new int[length];
            int leftPointer = left, rightPointer = middle;
            int tempPointer = 0;
            while ((leftPointer <= middle - 1) && (rightPointer <= right)) {
                if (array[leftPointer] < array[rightPointer]) {
                    temp[tempPointer++] = array[leftPointer++];
                } else {
                    temp[tempPointer++] = array[rightPointer++];
                }
            }
            while (leftPointer <= middle - 1) {
                temp[tempPointer++] = array[leftPointer++];
            }
            while (rightPointer <= right) {
                temp[tempPointer++] = array[rightPointer++];
            }
            for (int i = 0; i < length; i++) {
                array[left + i] = temp[i];
            }
        }
    }
}
