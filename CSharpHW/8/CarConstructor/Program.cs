using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructor {
    class Program {
        static void Main(string[] args) {
            Engine engine = new Engine("BMW", (ushort)300);
            Transmission transmission = new Transmission("B-123m", 0.9);
            Color carColor = Color.Standard.Blue;
            Car car = CarConstructor.Construct(engine, carColor, transmission);
            Console.WriteLine(car.ToString());
            Transmission tr = new Transmission("asdsa", 0.1);

            Engine engine2 = new Engine("Daimler", (ushort)400);
            car = CarConstructor.Reconstruct(car, engine2);
            Console.WriteLine("\nAfter reconstruction:");
            Console.WriteLine(car.ToString());

            Console.ReadLine();
        }
    }
}
