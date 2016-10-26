using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuning {
    class Program {
        static void Main(string[] args) {
            Car car = new Car(2000, "BMW", Color.Standard.Green);
            Console.WriteLine(car.ToString());
            car = TuningAttelier.TuneCar(car);
            Console.WriteLine("After tuning: ");
            Console.WriteLine(car.ToString());
            Console.ReadLine();
        }
    }
}
