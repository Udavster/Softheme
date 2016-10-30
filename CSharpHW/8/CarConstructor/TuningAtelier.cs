using System;

namespace CarConstructor {
    static class TuningAttelier {
        public static Car TuneCar(Car car) {
            car.Color = Color.Standard.Red;
            return car;
        }
    }
}
