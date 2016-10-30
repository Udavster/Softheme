using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CustomArray {
    class CustomArray<T> where T : IEquatable<T> {
        private T[] arr;
        private int currIndex;
        public const int stdInitialSize = 16;
        public const int stdAddBy = 5;
        private int _addBy;
        public bool Verbose { get; set; }
        public bool VerboseOnMemoryAlloc { get; set; }


        public CustomArray(int size = stdInitialSize, int addBy = stdAddBy) {
            arr = new T[size];
            _addBy = addBy;
            currIndex = 0;
        }
        public CustomArray(T[] arr) {
            this.arr = arr;
            currIndex = arr.Length - 1;
        }

        public int Length {
            get { return currIndex + 1; }
        }
        public T this[int i] {
            get {
                if (i < 0 || i > arr.Length) throw new ArgumentOutOfRangeException();
                return arr[i];
            }
        }

        public T GetByIndex(int i) {
            return this[i];
        }

        public bool Contains(T el) {
            for (int i = 0; i < arr.Length; i++) {
                if ((arr[i] != null) && (arr[i].Equals(el))) return true;
            }
            return false;
        }

        public CustomArray<T> Add(T el) {
            if (currIndex == arr.Length) {
                Array.Resize<T>(ref arr, arr.Length + _addBy);
                if (Verbose || VerboseOnMemoryAlloc)
                    Console.WriteLine("Allocated memory for {0} new objects (of type {1})", _addBy, el.GetType());
            }
            arr[currIndex] = el;
            if (Verbose)
            {
                Console.WriteLine("Added ({0}) to array", el.ToString());
            }
            currIndex++;
            return this;
        }

    }
}
