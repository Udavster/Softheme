using System;

namespace CarConstructor {

    class Car {
        public Car(Engine engine, Transmission transmission, Color color, string model = default(string), int? year = null) {
            this.Year = year;
            this.Model = model;
            this.Engine = engine;
            this.Transmission = transmission;
            this.Color = color;
        }

        public Engine Engine { get; private set; }
        public Transmission Transmission { get; private set; }
        public string Model { get; private set; }
        public Color Color { get; set; }
        public int? Year { get; private set; }

        public Car ChangeEngine(Engine engine) {
            this.Engine = engine;
            return this;
        }
        public override string ToString() {
            return String.Format("Car is produced in {0}, model: {1}, color: {2}. " +
                "Tech info: engine - ({3}), transmission - ({4})",
                Year, Model ?? "(not known)",
                this.Color.ToString(), Engine.ToString(), Transmission.ToString());
        }
    }
}
