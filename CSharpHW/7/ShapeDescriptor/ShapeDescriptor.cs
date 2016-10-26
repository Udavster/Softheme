using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDescriptor {
    class ShapeDescriptor {
        public string ShapeType { get; private set; }
        public Point[] point;
        public ShapeDescriptor() {
            ShapeType = "void";
            point = null;
        }
        public ShapeDescriptor(Point point){
            ShapeType = "point";
            this.point = new Point[] { point };
        }
        public ShapeDescriptor(Point[] point){
            ShapeType = "poly";
            this.point = point;
        }
    }
}
