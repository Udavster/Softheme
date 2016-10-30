using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructor {
    class Engine {
        public Engine(string producerName, UInt16 horsePower) {
            ProducerName = producerName;
            HorsePower = horsePower;
        }
        public string ProducerName { get; private set; }
        public UInt16 HorsePower { get; private set; }
        public override string ToString() {
            return String.Format("Engine of {0}, with {1} horse powers", ProducerName, HorsePower);
        }
    }
}
