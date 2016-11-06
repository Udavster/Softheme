using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<int,int> a = new Dictionary<int, int>();
            ShowDemoQueue();
            Console.WriteLine();
            ShowDemoStack();
            ShowDemoDictionary();
            Console.ReadLine();
        }

        static void ShowDemoQueue()
        {
            CustomQueue<int> queue = new CustomQueue<int>(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine("Queue element count: {0}", queue.Count);
            Console.WriteLine("It looks like: {0}", queue.ToString());
            Console.WriteLine("Lets dequeue the element: {0}", queue.Dequeue());
            Console.WriteLine("And the previous one: {0}", queue.Dequeue());
            Console.WriteLine("It looks like: {0}", queue.ToString());
        }
        
        static void ShowDemoStack()
        {
            CustomStack<int> stack = new CustomStack<int>(1);
            stack.Push(2).Push(3).Push(4);
            Console.WriteLine("Stack element count: {0}", stack.Count);
            Console.WriteLine(stack.ToString());
            Console.WriteLine("Lets pop the element: {0}", stack.Pop());
            Console.WriteLine("And the next one: {0}", stack.Pop());
            Console.WriteLine("Now the stack is: {0}", stack.ToString());
            Console.WriteLine("Lets pop another one: {0}", stack.Pop());
            Console.WriteLine("Lets pop and one more element: {0}", stack.Pop());
            Console.WriteLine("Now the stack is: {0}", stack.ToString());
        }
        static void ShowDemoDictionary()
        {
            Console.WriteLine("\nDemo dictionary:");

            KeyValuePair<int, string> pair = new KeyValuePair<int, string>(0,"zero");
            CustomDictionary<int, string> b = new CustomDictionary<int, string>(pair);
            b.Add(1, "one").Add(2, "two").Add(3, "three");
            
            Console.WriteLine(b.ToString());
            Console.WriteLine("Elements number: {0}", b.Count);

            Console.WriteLine("Remove element with key 2:");
            b.Remove(2);
            Console.WriteLine(b.ToString());
            Console.WriteLine("Elements number: {0}", b.Count);            
        }
    }
}
