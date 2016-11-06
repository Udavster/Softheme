using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileNetwork
{
    class MobileOperator
    {
        public MobileOperator(int maxNumber, int minNumber = 0)
        {
            subscribers = new Dictionary<int, MobileAccount>();
            numberGenerator = new Random();
            MinNumber = minNumber;
            MaxNumber = maxNumber;
            callsJournal = new List<KeyValuePair<int, int>>();
            smsJournal = new List<KeyValuePair<int, int>>();
        }
        private int MinNumber;
        private int MaxNumber;
        private Random numberGenerator;
        private Dictionary<int, MobileAccount> subscribers;
        private List<KeyValuePair<int, int>> callsJournal;
        private List<KeyValuePair<int, int>> smsJournal;
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
        public void HandleCall(MobileAccount sender, int receiver)
        {
            MobileAccount mobileAccount = GetAccountByNumber(receiver);
            mobileAccount.ReceiveCall(sender.Number);
            callsJournal.Add(new KeyValuePair<int, int>(sender.Number, receiver));
        }
        public void HandleSms(MobileAccount sender, int receiver, string text)
        {
            MobileAccount mobileAccount = GetAccountByNumber(receiver);
            mobileAccount.ReceiveSms(sender.Number, text);
            smsJournal.Add(new KeyValuePair<int, int>(sender.Number, receiver));
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
            } catch (ArgumentException)
            {
                throw new ArgumentException(
                    String.Format("Such number({0}) already exists!",
                        mobileAccount.Number)
                );
            }
        }

    }
}
