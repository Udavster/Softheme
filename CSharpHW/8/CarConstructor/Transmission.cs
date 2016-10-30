using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructor {
    class Transmission {
        public Transmission(string modelName, double ECE) {
            this.ModelName = modelName;
            this.ECE = ECE;
        }
        private double _ECE;
        //Energy conversion efficiency
        public double ECE {
            get {
                return _ECE;
            }
            private set {
                if ((value >= 1) || (value < 0)) {
                    throw new ArgumentException("Energy conversion efficiency can only be"
                        + " a number between 0 (inclusive) and 1(exclusive)");
                }
                _ECE = value;
            }
        }
        public string ModelName { get; private set; }
        public override string ToString() {
            return String.Format("Transmission of {0} model, with ECE = {1}", ModelName, ECE);
        }
    }
}
