using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileNetwork {
    class MobileOperator {
        public MobileOperator(int maxNumber, int minNumber = 0) {
            subscribers = new Dictionary<int, MobileAccount>();
            numberGenerator = new Random();
            MinNumber = minNumber;
            MaxNumber = maxNumber;
        }
        private int MinNumber;
        private int MaxNumber;
        private Random numberGenerator;
        private Dictionary<int, MobileAccount> subscribers;
        public int SubscribersCount {
            get {
                return subscribers.Count;
            }
        }
        public MobileAccount GetAccountByNumber(int number) {
            MobileAccount mobileAccount = null;
            try {
                mobileAccount = subscribers[number];
            } catch (Exception) {
                throw new ArgumentException("No such number in the network");
            }
            return mobileAccount;
        }
        public void HandleCall(MobileAccount sender, int receiver) {
            MobileAccount mobileAccount = GetAccountByNumber(receiver);
            mobileAccount.ReceiveCall(sender.Number);
        }
        public void HandleSms(MobileAccount sender, int receiver, string text) {
            MobileAccount mobileAccount = GetAccountByNumber(receiver);
            mobileAccount.ReceiveSms(sender.Number, text);
        }
        public int GetFreeNumber() {
            int number = 0;
            try {
                while (true) {
                    number = numberGenerator.Next(MinNumber, MaxNumber + 1);
                    MobileAccount acc = this.subscribers[number];
                }
            } catch (Exception) {
                return number;
            }
        }
        public void Register(MobileAccount mobileAccount) {
            try {
                this.subscribers.Add(mobileAccount.Number, mobileAccount);
            } catch (ArgumentException) {
                throw new ArgumentException(
                    String.Format("Such number({0}) already exists!", 
                        mobileAccount.Number)
                );
            }
        }
    }
}
