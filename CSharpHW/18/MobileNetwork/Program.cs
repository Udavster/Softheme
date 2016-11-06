using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileNetwork {
    class Program {

        static void Main(string[] args) {
            int maxPhoneNum = 380000;
            MobileOperator Verizon = new MobileOperator(maxPhoneNum);
            MobileAccount firstSubscriber = new MobileAccount(Verizon,1);
            MobileAccount secondSubscriber = new MobileAccount(Verizon, 2);
            MobileAccount anotherSubscriber = new MobileAccount(Verizon);

            Console.WriteLine("Number generated automatically for third subscriber: {0}",
                anotherSubscriber.Number);
            
            secondSubscriber.AddNumberToPhoneBook(1, "Ramin Djavadi");
            firstSubscriber.AddNumberToPhoneBook(2, "Jonathan Nolan");

            Console.WriteLine("\nSms from someone you know:");
            firstSubscriber.SendSms(2, "Hello, how 're you?");
            secondSubscriber.SendSms(1, "Fine, thanks");

            Console.WriteLine("\nSms from someone you don't:");
            anotherSubscriber.SendSms(1, "Where's my money?");

            Console.WriteLine("\nCalls:");
            anotherSubscriber.MakeCall(1);
            firstSubscriber.MakeCall(2);
            
            Console.WriteLine("\nSubscribers number: {0}", Verizon.SubscribersCount);
            Console.ReadLine();
        }
        
    }
    
}
