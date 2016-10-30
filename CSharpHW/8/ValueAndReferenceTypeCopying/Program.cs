using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypeCopying {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Creating user (Vasya, pass - abcd)");
            User user = new User("Vasya", "abcd");
            Console.WriteLine("Creating user2 = user");
            User user2 = user;
            Console.WriteLine("Changing user2 password (to 1234)");
            user2.ChangePassword("abcd", "12345");
            Console.WriteLine("Does the user have the old password(abcd)? - {0}", 
                user.CheckPassword("abcd").ToString());

            Console.WriteLine();

            int value = 123;
            Console.WriteLine("value is {0}", value.ToString());
            int value2 = value;
            Console.WriteLine("value2 = value (= {0})", value2.ToString());
            value2 = 444;
            Console.WriteLine("Changed value2 to {0}", value2.ToString());
            Console.WriteLine("value is still {0}", value.ToString());            
            Console.ReadLine();
        }
    }
}
