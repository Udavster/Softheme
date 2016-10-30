using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printers {
    public class PhotoPrinter:Printer {
        public override void Print(string s)
        {
            base.Print(s);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Photo printer");
            Console.ResetColor();
        }
        public void Print(Photo photo) {
            base.Print(String.Format("\nThis is image called {0} of size {1} bytes\t", photo.Name, photo.Size));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Photo printer");
            Console.ResetColor();
        }

    }
}
