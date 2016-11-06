using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class CustomNode<T>
    {
        public CustomNode(T data, CustomNode<T> previous = null, CustomNode<T> next = null  )
        {
            this.Data = data;
            this.Previous = previous;
            this.Next = next;
        }

        public T Data { get; set; }
        public CustomNode<T> Previous { get; set; }
        public CustomNode<T> Next { get; set; }
    }
}
