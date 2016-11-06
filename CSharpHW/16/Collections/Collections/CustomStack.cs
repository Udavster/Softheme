using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class CustomStack<T>: IEnumerable, IEnumerable<T>
    {
        private CustomNode<T> head;
        //private CustomNode<T> tail;

        public int Count { get; private set; }
        public CustomStack()
        {
            this.Count = 0;
        }
        public CustomStack(T head)
        {
            this.head = new CustomNode<T>(head);
            //this.tail = this.head;
            this.Count = 1;
        }
        public CustomStack<T> Push(T element)
        {
            CustomNode<T> node = new CustomNode<T>(element);
            node.Next = this.head;
            if (this.head != null)
            {
                this.head.Previous = node;
            }
            this.head = node;
            this.Count++;
            return this;
        }

        public T Pop()
        {
            CustomNode<T> result = this.head;
            if (this.head == null)
            {
                throw new NullReferenceException("No elements to pop");
            }
            this.head = this.head.Next;
            if (this.head != null)
            {
                this.head.Previous = null;
            }
            this.Count--;
            return result.Data;
        }

        public T Peek()
        {
            if (this.head == null)
            {
                throw new NullReferenceException("No elements to peek");
            }
            return this.head.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var array = ToArray();

            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];
            CustomNode<T> node = this.head;
            for (int i = 0; i < this.Count; i++)
            {
                result[i] = node.Data;
                node = node.Next;
            }
            return result;
        }
        public override string ToString()
        {
            string s = "[head:";
            CustomNode<T> node = this.head;
             
            for (int i = 0; i < this.Count - 1; i++)
            {
                s += String.Format("{0}->", node.Data.ToString());
                node = node.Next;
            }
            if (this.Count != 0)
            {
                s += node.Data.ToString();
            }
            s += ":tail]";
            return s;
        }
    }

}
