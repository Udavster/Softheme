using System;
using Printers;


namespace ExtentionProject {
    public static class PrintersExtention {
        public static void Print(this Printers.Printer printer, string[] text) {
            for (int i = 0; i < text.Length; i++) {
                printer.Print(text[i]);
            }
        }
        public static void Print(this Printers.ColorPrinter printer, string[] text, ConsoleColor textColor) {
            for (int i = 0; i < text.Length; i++) {
                printer.Print(text[i], textColor);
            }
        }
        public static void Print(this Printers.PhotoPrinter printer, Photo[] photos) {
            for (int i = 0; i < photos.Length; i++) {
                printer.Print(photos[i]);
            }
        }
    }
}
