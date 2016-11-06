using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileNetwork
{
    class MobileAccount
    {
        public delegate void CallHandle(MobileAccount sender, int receiver);
        public delegate void SmsHandle(MobileAccount sender, int receiver, string text);
        private event CallHandle CallMade;
        private event SmsHandle SmsSent;
        readonly int number;
        private Dictionary<int, string> phoneBook;
        public int Number
        {
            get
            {
                return this.number;
            }
        }
        public MobileAccount(MobileOperator mobileOperator, int number)
        {
            if (mobileOperator == null)
            {
                throw new ArgumentNullException();
            }
            CallMade += mobileOperator.HandleCall;
            SmsSent += mobileOperator.HandleSms;
            this.number = number;
            mobileOperator.Register(this);
            phoneBook = new Dictionary<int, string>();
        }

        public MobileAccount(MobileOperator mobileOperator) :
            this(mobileOperator, mobileOperator.GetFreeNumber()) { }

        public void MakeCall(int receiver)
        {
            try
            {
                CallMade.Invoke(this, receiver);
            } catch (ArgumentException ex)
            {
                Console.WriteLine("{0}: making call: {1}", this.Number, ex.Message);
            }
        }
        public void SendSms(int receiver, string message)
        {
            try
            {
                SmsSent.Invoke(this, receiver, message);
            } catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", this.Number, ex.Message);
            }
        }
        public void ReceiveSms(int sender, string text)
        {
            Console.WriteLine("{0}: Received sms from {1}\n\t with text '{2}'",
                this.Number, GetNameByNumber(sender) ?? sender.ToString(), text);
        }
        public void ReceiveCall(int sender)
        {
            Console.WriteLine("{0}: Received call from {1}",
                this.Number, GetNameByNumber(sender)??sender.ToString());
        }
        public void AddNumberToPhoneBook(int number, string name)
        {
            try
            {
                phoneBook.Add(number, name);
            } catch (ArgumentException)
            {
                phoneBook[number] = name;
            }
        }
        private string GetNameByNumber(int number)
        {
            string name = null;
            try
            {
                name = phoneBook[number];
            } catch (KeyNotFoundException) { }
            return name;
        }
    }
}
