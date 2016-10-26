using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuning {
    class Color {
        private readonly byte _red, _green, _blue;

        public Color() { }

        public Color(int red, int green, int blue) {
            this._red = (byte)red;
            this._green = (byte)green;
            this._blue = (byte)blue;
        }

        public byte Red {
            get { return _red; }
        }

        public byte Green {
            get { return _green; }
        }

        public byte Blue {
            get { return _blue; }
        }
        public static Color Invert(Color color) {
            return new Color(255 - color.Red, 255 - color.Green, 255 - color.Blue);
        }
        public struct Standard {
            public static Color Red;
            public static Color Green;
            public static Color Blue;
            public static Color White;
            public static Color Black;
            static Standard() {
                Red = new Color(255, 0, 0);
                Green = new Color(0, 255, 0);
                Blue = new Color(0, 0, 255);
                White = new Color(255, 255, 255);
                Black = new Color(0, 0, 0);
            }
        }

        public override string ToString() {
            return string.Format("({0},{1},{2})", Red, Green, Blue);
        }
    }
}
