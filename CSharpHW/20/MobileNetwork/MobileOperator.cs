using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileNetwork
{
    class MobileOperator
    {
        public MobileOperator(int maxNumber, int minNumber = 0, int callPricing = 0, int smsPricing = 0)
        {
            subscribers = new Dictionary<int, MobileAccount>();
            numberGenerator = new Random();
            MinNumber = minNumber;
            MaxNumber = maxNumber;
            callsJournal = new List<KeyValuePair<int, int>>();
            smsJournal = new List<KeyValuePair<int, int>>();
            moneyOnAccount = new Dictionary<int, int>();
            CallPricing = callPricing;
            SmsPricing = smsPricing;
        }

        private int MinNumber;
        private int MaxNumber;
        private Random numberGenerator;
        private Dictionary<int, MobileAccount> subscribers;
        private List<KeyValuePair<int, int>> callsJournal;
        private List<KeyValuePair<int, int>> smsJournal;
        private Dictionary<int, int> moneyOnAccount;
        public int CallPricing { get; private set; }
        public int SmsPricing { get; private set; }


        public SubscriberStats[] GetMostCalledSubscribers(int number)
        {
            return callsJournal.GroupBy(x => x.Value)
                    .Select(group => new SubscriberStats()
                    {
                        phoneNumber = group.Key,
                        callsNumber = group.Count()
                    }).OrderBy(x => -x.callsNumber).Take(number).ToArray();
        }
        public SubscriberStats[] GetMostActiveSubscribers(int number)
        {
            var callStats = callsJournal.GroupBy(x => x.Key)
                    .Select(group => new SubscriberStats()
                    {
                        phoneNumber = group.Key,
                        callsNumber = group.Count(),
                        metric = group.Count()
                    });

            var smsStats = smsJournal.GroupBy(x => x.Key)
                    .Select(group => new SubscriberStats()
                    {
                        phoneNumber = group.Key,
                        smsNumber = group.Count(),
                        metric = 0.5 * group.Count()
                    });
            var stats = callStats.Concat(smsStats);
            return stats.GroupBy(x => x.phoneNumber).Select(group => new SubscriberStats()
            {
                phoneNumber = group.Key,
                callsNumber = group.Sum(x => x.callsNumber),
                smsNumber = group.Sum(x => x.smsNumber),
                metric = group.Sum(x => x.metric)
            }).OrderBy(x => -x.metric).Take(number).ToArray();
        }
        public int SubscribersCount
        {
            get
            {
                return subscribers.Count;
            }
        }
        public MobileAccount GetAccountByNumber(int number)
        {
            MobileAccount mobileAccount = null;
            try
            {
                mobileAccount = subscribers[number];
            } catch (Exception)
            {
                throw new ArgumentException(
                    String.Format("No such number({0}) in the network", number)
                    );
            }
            return mobileAccount;
        }
        public OperatorMessage HandleCall(MobileAccount sender, int receiver)
        {
            MobileAccount mobileAccount = GetAccountByNumber(receiver);
            if (moneyOnAccount[sender.Number] < this.CallPricing)
            {
                return new OperatorErrorMessage(){
                    Text = "Insufficient funds. You have: $" + moneyOnAccount[sender.Number]
                };
            }
            moneyOnAccount[sender.Number] -= this.CallPricing;
            mobileAccount.ReceiveCall(sender.Number);
            callsJournal.Add(new KeyValuePair<int, int>(sender.Number, receiver));
            return new OperatorInfoMessage();
        }
        public OperatorMessage HandleSms(MobileAccount sender, int receiver, string text)
        {
            MobileAccount mobileAccount = GetAccountByNumber(receiver);
            if (moneyOnAccount[sender.Number] < this.SmsPricing)
            {
                return new OperatorErrorMessage() {
                    Text = "Insufficient funds. You have: $" + moneyOnAccount[sender.Number]
                };
            }
            moneyOnAccount[sender.Number] -= this.SmsPricing;
            mobileAccount.ReceiveSms(sender.Number, text);
            smsJournal.Add(new KeyValuePair<int, int>(sender.Number, receiver));
            return null;
        }
        public int GetFreeNumber()
        {
            int number = 0;
            try
            {
                while (true)
                {
                    number = numberGenerator.Next(MinNumber, MaxNumber + 1);
                    MobileAccount acc = this.subscribers[number];
                }
            } catch (Exception)
            {
                return number;
            }
        }
        public void Register(MobileAccount mobileAccount)
        {
            try
            {
                this.subscribers.Add(mobileAccount.Number, mobileAccount);
                this.moneyOnAccount.Add(mobileAccount.Number, 0);
            } catch (ArgumentException)
            {
                throw new ArgumentException(
                    String.Format("Such number({0}) already exists!",
                        mobileAccount.Number)
                );
            }
        }
        public void AddFunds(int number, int summ)
        {
            if (summ < 0)
            {
                throw new ArgumentException("Invalid summ. Should be >=0");
            }
            try
            {
                this.moneyOnAccount[number] += summ;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Added funds for {0}. Now it has ${1} on account",
                    number, this.moneyOnAccount[number]);
                Console.ResetColor();
            } catch (Exception)
            {
                throw new ArgumentException(
                    String.Format("There is no such number ({0})", number)
                      );
            }
        }

    }
}
