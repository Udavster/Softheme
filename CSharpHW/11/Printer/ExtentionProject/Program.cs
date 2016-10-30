using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Printer = Printers.Printer;
using ColorPrinter = Printers.ColorPrinter;
using PhotoPrinter = Printers.PhotoPrinter;
using Photo = Printers.Photo;

namespace ExtentionProject {
    class Program {
        static void Main(string[] args) {
            ColorPrinter colorPrinter = new ColorPrinter();
            colorPrinter.Print("Who am I? ");
            colorPrinter.Print(new string[] { "\nPrinting in blue  ", "Seems cool, right?"}, ConsoleColor.Blue);
            PhotoPrinter photoPrinter = new PhotoPrinter();
            Photo waterfall = new Photo("Waterfall", 1024);
            Photo mountain = new Photo("Mountain", 2048);
            photoPrinter.Print(new Photo[] { waterfall, mountain});
            photoPrinter.Print("Who am I? ");
            Printer printer = colorPrinter;
            printer.Print(new string[] { "I am used as base now!)", "And I can print several lines of text!)" });
            printer = photoPrinter;
            printer.Print("I am used as base now!)");

            printer = new Printer();
            printer.Print(new string[] { "I am base now!)\n", "Bye!"});
            Console.ReadLine();
        }
    }
}
