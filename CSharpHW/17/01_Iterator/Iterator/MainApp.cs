using System;
using System.Collections.Generic;

namespace Iterator
{
    class MainApp
    {
        static void Main()
        {
            ConcreteAggregate<int> b = new ConcreteAggregate<int>();
            b[0] = 1;
            b[1] = 2;
            b[2] = 3;
            b[3] = 4;

            ConcreteIterator<int> j = new ConcreteIterator<int>(b);

            Console.WriteLine("Iterating over collection:");

            while (!j.IsDone())
            {
                var itemT = j.Next();
                Console.WriteLine(itemT);
                
            };

            Console.ReadKey();
        }
    }
}