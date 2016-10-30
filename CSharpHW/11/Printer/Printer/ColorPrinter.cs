using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printers {
    public class ColorPrinter:Printer {
        public override void Print(string s)
        {
            base.Print(s);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Color printer");    
            Console.ResetColor();
        }

        public void Print(string s, ConsoleColor textColor)
        {
            Console.ForegroundColor = textColor;
            base.Print(s);
            Console.WriteLine("Color printer");
            Console.ResetColor();
        }
    }
}
