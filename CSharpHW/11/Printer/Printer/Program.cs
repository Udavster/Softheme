using System;

namespace Printers {
    class Program {
        static void Main(string[] args) {
            ColorPrinter colorPrinter = new ColorPrinter();
            colorPrinter.Print("Who am I? ");
            colorPrinter.Print("\nPrinting in blue  ", ConsoleColor.Blue);
            PhotoPrinter photoPrinter = new PhotoPrinter();
            Photo waterfall = new Photo("Waterfall",1024);
            photoPrinter.Print(waterfall);
            photoPrinter.Print("Who am I? ");
            Printer printer = colorPrinter;
            printer.Print("I am used as base now!)");
            printer = photoPrinter;
            printer.Print("I am used as base now!)");

            printer = new Printer();
            printer.Print("I am base now!)");
            Console.ReadLine();
        }
    }
}
