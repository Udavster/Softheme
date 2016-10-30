using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery {
    class Program {
        static void Main(string[] args) {
            try {
                Lottery lottery = new Lottery(6);
                do {
                    try {
                        Console.WriteLine("Please, enter lottery number - 6 digits [1-9] or 'exit' to leave");
                        string inp = Console.ReadLine();
                        if (inp.ToUpper() == "EXIT") return;
                        if (lottery.CheckWin(inp)) {
                            Console.WriteLine("You won!");
                        } else {
                            Console.WriteLine("Sorry, may be another time... Wining number was {0}", lottery.LastWonNum);
                        }
                    } catch (ArgumentException ex) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please, validate your input: {0}", ex.Message);
                        Console.ResetColor();
                    }
                } while (true);
            } catch (Exception ex) {
                Console.WriteLine("Sorry, unhandled exception happened ({0})", ex.Message);
                Console.ReadLine();
            }
        }
    }
}

