using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuning {
    static class TuningAttelier {
        public static Car TuneCar(Car car) {
            car.Color = Color.Standard.Red;
            return car;
        }
    }
}
