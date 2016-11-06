using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class CustomDictionary<T, U> where T : IEquatable<T>
    {
        private CustomNode<KeyValuePair<T, U>> head;
        private CustomNode<KeyValuePair<T, U>> tail;
        public int Count { get; set; }

        public CustomDictionary() { }

        public CustomDictionary(KeyValuePair<T, U> firstElement)
        {
            head = new CustomNode<KeyValuePair<T, U>>(firstElement);
            tail = head;
            Count++;
        }

        private void CheckKeyExists(T key)
        {
            CustomNode<KeyValuePair<T, U>> node = this.head;
            for (int i = 0; i < this.Count; i++)
            {
                if (node.Data.Key.Equals(key))
                {
                    throw new ArgumentException("This key already exists in the dictionary");
                }
                node = node.Next;
            }
        }
        public CustomDictionary<T, U> Add(KeyValuePair<T, U> element)
        {
            CheckKeyExists(element.Key);
            if (tail != null)
            {
                tail.Next = new CustomNode<KeyValuePair<T, U>>(element) { Previous = tail };
            } else
            {
                tail = new CustomNode<KeyValuePair<T, U>>(element);
                head = tail;
            }
            tail = tail.Next;
            Count++;
            return this;
        }

        public CustomDictionary<T, U> Add(T key, U value)
        {
            return this.Add(new KeyValuePair<T, U>(key, value));
        }

        public CustomDictionary<T, U> Remove(T key)
        {
            CustomNode<KeyValuePair<T, U>> node = this.head;
            for (int i = 0; i < this.Count; i++)
            {
                if (node.Data.Key.Equals(key))
                {
                    if (node.Previous == null)
                    {
                        this.head = node.Next;
                    } else
                    {
                        node.Previous.Next = node.Next;
                        if (node.Next != null)
                        {
                            node.Next.Previous = node.Previous;
                        }
                    }
                    this.Count--;
                }
                node = node.Next;
            }
            return this;
        }

        public U this[T key]
        {
            get
            {
                CustomNode<KeyValuePair<T, U>> node = this.head;
                for (int i = 0; i < this.Count; i++)
                {
                    if (node.Data.Key.Equals(key)) return node.Data.Value;
                    node = node.Next;
                }
                throw new KeyNotFoundException();
            }
            set
            {
                CheckKeyExists(key);
                this.Add(new KeyValuePair<T, U>(key, value));
            }
        }
        public override string ToString()
        {
            string s = "[";
            CustomNode<KeyValuePair<T, U>> node = this.head;

            for (int i = 0; i < this.Count - 1; i++)
            {
                s += String.Format(" {0};", node.Data.ToString());
                node = node.Next;
            }
            if (this.Count != 0)
            {
                s += " " + node.Data.ToString();
            }
            s += " ]";
            return s;
        }

    }
}
