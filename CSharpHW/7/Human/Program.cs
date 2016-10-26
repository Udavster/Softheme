using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human {
    class Program {
        static void Main(string[] args) {
            Human human = new Human("Grey", "Goo");
            Console.WriteLine(human.GetHashCode());
            Human human2 = new Human("Grey", "Goo");
            Console.WriteLine(human2.GetHashCode());
            PrintHumanComparison(human, human2);
            DateTime date = new DateTime(2010,11,12);
            Human human3 = new Human("John", "Doe", date);
            PrintHumanComparison(human2, human3);
            Console.ReadLine();
        }
        static void PrintHumanComparison(Human human1, Human human2) {
            Console.WriteLine("Is human ({0}) equal to human2 ({1})? {2}",
                human1.ToString(), human2.ToString(), (human1.Equals(human2)).ToString());
        }
    }
}
