using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDescriptor {
    class Program {
        static void Main(string[] args) {
            ShapeDescriptor nothing = new ShapeDescriptor();
            Console.WriteLine(nothing.ShapeType);
            Point point = new Point(1, 1, 1);
            ShapeDescriptor dot = new ShapeDescriptor(point);
            Console.WriteLine(dot.ShapeType);
            Point point2 = new Point(2, 2, 2);
            ShapeDescriptor poly = new ShapeDescriptor(new Point[]{point, point2});
            Console.WriteLine(poly.ShapeType);
            Console.ReadLine();
        }
    }
}
