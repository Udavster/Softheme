using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printers {
    public class Photo {
        public Photo(string name, int size)
        {
            this.Name = name;
            this.Size = size;
        }
        public int Size { get; private set; }
        public string Name { get; private set; }
    }
}
