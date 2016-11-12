using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace MobileNetwork
{
    public class MobileAccount
    {
        public delegate OperatorMessage CallHandle(MobileAccount sender, int receiver);
        public delegate OperatorMessage SmsHandle(MobileAccount sender, int receiver, string text);
        private event CallHandle CallMade;
        private event SmsHandle SmsSent;
        readonly int number;
        protected Dictionary<int, string> phoneBook;
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
                var operatorMessage = CallMade.Invoke(this, receiver);
                HandleOperatorResponse(operatorMessage);
            } catch (ArgumentException ex)
            {
                Console.WriteLine("{0}: making call: {1}", this.Number, ex.Message);
            }
        }
        public void SendSms(int receiver, string message)
        {
            try
            {
                var operatorMessage = SmsSent.Invoke(this, receiver, message);
                HandleOperatorResponse(operatorMessage);
            } catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", this.Number, ex.Message);
            }
        }
        private void HandleOperatorResponse(OperatorMessage operatorMessage)
        {
            var oma = Attribute.GetCustomAttribute(
                operatorMessage.GetType(), typeof(OperatorMessageAttribute)
                );
            var operatorMessageAttribute = oma as OperatorMessageAttribute;
            if (operatorMessageAttribute != null)
            {
                if (operatorMessageAttribute.Status == OperatorMessageStatus.Error)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0}: {1}", this.Number, operatorMessage.Text);
                    Console.ResetColor();
                }
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
