using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class CustomQueue<T> : IEnumerable, IEnumerable<T>
    {
        private CustomNode<T> head;
        private CustomNode<T> tail;

        public int Count { get; private set; }
        public CustomQueue()
        {
            this.Count = 0;
        }
        public CustomQueue(T head)
        {
            this.head = new CustomNode<T>(head);
            this.tail = this.head;
            this.Count = 1;
        }
        public CustomQueue<T> Enqueue(T element)
        {
            CustomNode<T> node = new CustomNode<T>(element);
            if (this.tail != null)
            {
                this.tail.Next = node;
            }
            node.Previous = this.tail;
            this.tail = node;
            this.Count++;
            return this;
        }

        public T Dequeue()
        {
            CustomNode<T> result = this.head;
            if (head == null)
            {
                throw new NullReferenceException("Nothing to dequeue");
            }
            this.head = this.head.Next;
            if (this.head != null)
            {
                this.head.Previous = null;
            }
            this.Count--;
            return result.Data;
        }

        public CustomNode<T> Peek()
        {
            if (this.head == null)
            {
                throw new NullReferenceException("No elements to peek");
            }
            return this.head;
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
