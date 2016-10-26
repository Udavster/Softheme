using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuning {

    class Car {
        public Car() { }

        public Car(int year, string model, Color color) {
            this.Year = year;
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; private set; }

        public Color Color { get; set; }

        public int Year { get; private set; }
        public override string ToString() {
            return string.Format("Car is produced in {0}, model: {1}, color: {2}", Year, Model, this.Color.ToString());
        }
    }
}
