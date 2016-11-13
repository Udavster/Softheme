using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxPhoneNum = 380000;
            MobileOperator Verizon = new MobileOperator(maxPhoneNum,0,callPricing: 2, smsPricing: 1);

            Console.WriteLine("How sms are working:");
            ShowSms(Verizon);

            Console.WriteLine("Press any key to see how calls are working:");
            Console.ReadLine();
            ShowCalls(Verizon);

            Console.WriteLine("Press any key to see how stats are working:");
            Console.WriteLine("Caution! 100 random calls and messages will be generated!");
            Console.ReadLine();
            ShowStatistics(Verizon);

            Console.ReadLine();
        }
        public static void ShowSms(MobileOperator mobileOperator)
        {
            MobileAccount firstSubscriber = new MobileAccount(mobileOperator, 1);
            MobileAccount secondSubscriber = new MobileAccount(mobileOperator, 2);
            MobileAccount anotherSubscriber = new MobileAccount(mobileOperator);

            Console.WriteLine("Number generated automatically for third subscriber: {0}",
                anotherSubscriber.Number);

            secondSubscriber.AddNumberToPhoneBook(1, "Ramin Djavadi");
            firstSubscriber.AddNumberToPhoneBook(2, "Jonathan Nolan");

            mobileOperator.AddFunds(1, 4);
            mobileOperator.AddFunds(2, 4);
            mobileOperator.AddFunds(anotherSubscriber.Number, 2);

            Console.WriteLine("\nSms from someone you know:");
            firstSubscriber.SendSms(2, "Hello, how 're you?");
            secondSubscriber.SendSms(1, "Fine, thanks");

            Console.WriteLine("\nSms from someone you don't:");
            anotherSubscriber.SendSms(1, "Where's my money?");

            Console.WriteLine();
        }
        public static void ShowCalls(MobileOperator mobileOperator)
        {
            Console.WriteLine("\nCalls:");
            
            MobileAccount thirdSubscriber = new MobileAccount(mobileOperator, 3);
            MobileAccount fourthSubscriber = new MobileAccount(mobileOperator, 4);
            mobileOperator.AddFunds(3, 35);
            mobileOperator.AddFunds(4, 3);

            thirdSubscriber.MakeCall(4);
            fourthSubscriber.MakeCall(3);
            fourthSubscriber.MakeCall(1);

            Console.WriteLine();
        }
        public static void ShowStatistics(MobileOperator mobileOperator)
        {
            MobileAccount[] subscribers = new MobileAccount[10];
            for (int i = 0; i < 10; i++)
            {
                subscribers[i] = new MobileAccount(mobileOperator);
                mobileOperator.AddFunds(subscribers[i].Number, 35);
            }

            Filler.GenerateRandomCalls(subscribers, 100);
            Filler.GenerateRandomSms(subscribers, 100);

            Console.WriteLine("\nTotal subscribers number: {0}", mobileOperator.SubscribersCount);

            Console.WriteLine("\n5 Most called: \n(number:\t calls)");
            SubscriberStats[] mostCalled = mobileOperator.GetMostCalledSubscribers(5);
            for (int i = 0; i < mostCalled.Length; i++)
            {
                Console.WriteLine("{0}:\t{1}", mostCalled[i].phoneNumber, mostCalled[i].callsNumber);
            }

            Console.WriteLine("\n5 Most active: \n(number: calls\tsms\tmetric)");
            SubscriberStats[] mostActive = mobileOperator.GetMostActiveSubscribers(5);
            for (int i = 0; i < mostActive.Length; i++)
            {
                Console.WriteLine("{0}:\t{1}\t{2}\t{3}", mostActive[i].phoneNumber, mostActive[i].callsNumber, mostActive[i].smsNumber, mostActive[i].metric);
            }

            Console.WriteLine();
        }
        

    }

}
