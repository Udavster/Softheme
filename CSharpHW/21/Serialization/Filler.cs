using System;
using System.Collections.Generic;
using System.Linq;
using MobileNetwork;

namespace Serialization
{
    static class Filler
    {
        public static MobileAccount[] CreateSubscribers(MobileOperator mobileOperator, int number)
        {
            MobileAccount[] result = new MobileAccount[number];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new MobileAccount(mobileOperator);
            }
            return result;
        }
        public static MobileAccountWithMemo[] CreateSubscribersWithMemo(MobileOperator mobileOperator, int number, bool Sequentially = false)
        {
            MobileAccountWithMemo[] result = new MobileAccountWithMemo[number];
            for (int i = 0; i < number; i++)
            {
                if (Sequentially)
                {
                    result[i] = new MobileAccountWithMemo(mobileOperator, i);
                } else
                {
                    result[i] = new MobileAccountWithMemo(mobileOperator); 
                }
            }
            return result;
        }
        public static void GenerateRandomCalls(MobileAccount[] subscribers, int callsNumber)
        {
            Random random = new Random();
            for (int i = 0; i < callsNumber; i++)
            {
                subscribers[random.Next(0, subscribers.Length)].
                    MakeCall(subscribers[random.Next(0, subscribers.Length)].Number);
            }
        }
        public static void GenerateRandomSms(MobileAccount[] subscribers, int callsNumber)
        {
            Random random = new Random();
            for (int i = 0; i < callsNumber; i++)
            {
                subscribers[random.Next(0, subscribers.Length)].
                    SendSms(subscribers[random.Next(0, subscribers.Length)].Number, "");
            }
        }
        public static void CreatePhonebooks(MobileAccount[] subscribers, int friendsNum)
        {
            Random random = new Random();
            for (int i = 0; i < friendsNum; i++)
            {
                subscribers[random.Next(0, subscribers.Length)].
                    AddNumberToPhoneBook(subscribers[random.Next(0, subscribers.Length)].Number, "name");
            }
        }
    }
}
