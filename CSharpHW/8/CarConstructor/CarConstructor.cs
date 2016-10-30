using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructor {
    static class CarConstructor {
        public static Car Construct(Engine engine, Color color, Transmission transmission, string model = null) {
            return new Car(engine, transmission, color, model, DateTime.Now.Year);
        }
        public static Car Reconstruct(Car car, Engine engine) {
            return car.ChangeEngine(engine);
        }
    }
}
