using System;

namespace Figures {
    class Program {
        static void Main(string[] args) {
            string normalText = "What figure do you want to draw? Input 1 for Triangle,\n"+
                " 2 for Square, 3 for Romb, 4 for all of them";
            int figureNum = GetInput(normalText, 1, 4);
            normalText = "What linear size should the figure (figures) have? " +
                "\n(Remember: Rombs like ours can only have odd linear size)";
            int linSize = GetInput(normalText, minValue: 1);
            switch (figureNum) {
                case 1:
                    PrintTriangle(linSize);
                    break;
                case 2:
                    PrintSquare(linSize);
                    break;
                case 3:
                    PrintRomb(linSize);
                    break;
                default:
                    PrintTriangle(linSize);
                    Console.WriteLine();
                    PrintSquare(linSize);
                    Console.WriteLine();
                    PrintRomb(linSize);
                    break;
            }
            Console.ReadLine();
        }
        static int GetInput(string normalText, 
            int minValue = int.MinValue, int maxValue = int.MaxValue) {
            bool properInput = true;
            int output;
            do {
                if (!properInput) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input, try again");
                    Console.ResetColor();
                }
                Console.WriteLine(normalText);
                properInput = Int32.TryParse(Console.ReadLine(), out output);
                properInput &= (output <= maxValue) && (output >= minValue);
            } while (!properInput);
            return output;
        }
        static void PrintTriangle(int linSize) {
            for (int i = 0; i < linSize; i++) {
                for (int j = 0; j <= i; j++) {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
        static void PrintSquare(int linSize) {
            for (int i = 0; i < linSize; i++) {
                for (int j = 0; j < linSize; j++) {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
        static void PrintRombRow(int linSize, int i) {
            for (int j = -linSize; j < -i; j++) {
                Console.Write("  ");
            }
            for (int j = -i; j <= i; j++) {
                Console.Write("* ");
            }
            for (int j = i; j < linSize; j++) {
                Console.Write("  ");
            }
            Console.WriteLine();
        }
        static void PrintRomb(int linSize) {
            if (linSize % 2 == 0) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Linear size of such Romb can only be an odd number!");
                Console.ResetColor();
                Console.WriteLine("Drawing as if it is {0}+1", linSize);
            }
            linSize = linSize / 2;
            for (int i = 0; i <= linSize; i++) {
                PrintRombRow(linSize, i);
            }
            for (int i = linSize - 1; i >= 0; i--) {
                PrintRombRow(linSize, i);
            }
        }
    }
}
