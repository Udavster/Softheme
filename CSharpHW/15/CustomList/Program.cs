using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList {
    class Program {
        static void Main(string[] args) {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3, 0);
            list.Add(4, 1);

            Console.WriteLine(list.ToString());
            Console.WriteLine("Is (1) in the list? {0}", list.Exists(1).ToString());
            Console.WriteLine("Is (3) in the list? {0}", list.Exists(3).ToString());
            Console.WriteLine("Is (5) in the list? {0}", list.Exists(5).ToString());
            Console.WriteLine();

            Console.WriteLine("Let's remove 3 element of the list (starting count from 0)");
            list.Remove(2);
            Console.WriteLine(list.ToString());
            Console.WriteLine("Let's remove 0 element of the list (starting count from 0)");
            list.Remove(0);
            Console.WriteLine(list.ToString());
            Console.WriteLine("Is (1) in the list? {0}", list.Exists(1).ToString());
            Console.WriteLine("Is (3) in the list? {0}", list.Exists(1).ToString());
            Console.WriteLine("List is {0} elements long", list.Length);

            Console.WriteLine("To array: ");
            int[] intArray = list.ToArray();
            for (int i = 0; i < intArray.Length; i++) {
                Console.Write("{0}, ", intArray[i]);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
    class DoublyLinkedList<T> where T : IEquatable<T> {
        DoublyLinkedElement<T> first;
        public int Length { get; private set; }
        public void Add(T element, int? position = null) {
            position = position ?? this.Length;
            if ((position < 0) || (position > this.Length)) {
                throw new ArgumentOutOfRangeException();
            }
            if (position == 0) {
                this.first = new DoublyLinkedElement<T>(element, next: first);
                this.Length++;
                return;
            }
            DoublyLinkedElement<T> pointer = this.first;
            for (int i = 1; i < position; i++) {
                pointer = pointer.Next;
            }
            if (pointer.Next == null) {
                pointer.Next = new DoublyLinkedElement<T>(element, previous: pointer);
            } else {
                DoublyLinkedElement<T> inserted = new DoublyLinkedElement<T>(element, previous: pointer, next: pointer.Next);
                pointer.Next.Previous = inserted;
                pointer.Next = inserted;
            }

            this.Length++;
        }
        public int IndexOf(T element) {
            DoublyLinkedElement<T> pointer = this.first;
            int num = 0;
            while (pointer != null) {
                if (pointer.content.Equals(element)) {
                    return num;
                }
                pointer = pointer.Next;
                num++;
            }
            return -1;
        }
        public bool Exists(T element) {
            return IndexOf(element) >= 0;
        }
        public void Remove(int num) {
            if ((num < 0) || (num >= this.Length)) {
                return;
            }
            if (num == 0) {
                if (this.first.Next != null) {
                    this.first.Next.Previous = null;
                }
                this.first = first.Next;
                this.Length--;
                return;
            }
            DoublyLinkedElement<T> pointer = this.first;

            for (int i = 0; i < num; i++) {
                pointer = pointer.Next;
            }
            if (pointer.Next != null) {
                pointer.Next.Previous = pointer.Previous;
            }
            pointer.Previous.Next = pointer.Next;
            this.Length--;
        }
        public T[] ToArray() {
            T[] result = new T[this.Length];
            DoublyLinkedElement<T> pointer = this.first;
            for (int i = 0; i < this.Length; i++) {
                result[i] = pointer.content;
                pointer = pointer.Next;
            }
            return result;
        }
        public override string ToString() {
            string s = "";
            DoublyLinkedElement<T> pointer = this.first;
            for (int i = 0; i < this.Length - 1; i++) {
                s += String.Format("{0}<->", pointer.content.ToString());
                pointer = pointer.Next;
            }
            s += String.Format("{0}", pointer.content.ToString());
            return s;
        }
    }
    class DoublyLinkedElement<T> {
        public T content;

        public DoublyLinkedElement<T> Previous { get; set; }
        public DoublyLinkedElement<T> Next { get; set; }
        public DoublyLinkedElement(T el, DoublyLinkedElement<T> previous = null, DoublyLinkedElement<T> next = null) {
            content = el;
            this.Previous = previous;
            this.Next = next;
        }
    }
}

