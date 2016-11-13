using System;
using System.Collections.Generic;
using System.Linq;
using MobileNetwork;

namespace Serialization
{
    class MobileOperatorWithMemo: MobileOperator//, IEquatable<MobileAccountWithMemo>
    {
        public MobileOperatorWithMemo(int maxNumber, int minNumber = 0, int callPricing = 0, int smsPricing = 0, bool silent = false):
            base(maxNumber, minNumber, callPricing, smsPricing, silent) { }
        public MobileOperatorWithMemo(MemoMobileOperator memo) :
            base(memo.MaxNumber, memo.MinNumber, memo.CallPricing, memo.SmsPricing) {
                this.subscribers = new Dictionary<int, MobileAccount>(memo.memoSubscribers.Length);
                for (int i = 0; i < memo.memoSubscribers.Length; i++)
                {
                    //creating subscribers automaticaly adds it to its operator
                    var subscriber = new MobileAccountWithMemo(this, memo.memoSubscribers[i]);
                }
                this.moneyOnAccount = new Dictionary<int, int>(memo.Funds.Length);
                for (int i = 0; i < memo.Funds.Length; i++)
                {
                    moneyOnAccount.Add(memo.Funds[i].Key, memo.Funds[i].Value);
                }
                this.smsJournal = memo.smsJournal.Select(x => new KeyValuePair<int, int>(x.Key, x.Value)).ToList();
                this.callsJournal = memo.callsJournal.Select(x => new KeyValuePair<int, int>(x.Key, x.Value)).ToList();
        }
        public MemoMobileOperator GetMemo(bool withCallsJournal = false, bool withSmsJournal = false)
        {
            MemoMobileAccount[] memoAccounts = new MemoMobileAccount[this.subscribers.Count];
            int i = 0;
            foreach (var item in this.subscribers)
            {
                MobileAccountWithMemo temp = item.Value as MobileAccountWithMemo;
                if (temp != null)
                {
                    memoAccounts[i] = temp.GetMemo();
                    i++; 
                }
            }
            Array.Resize(ref memoAccounts, i);

            var funds = this.moneyOnAccount.
                Select(x => new CustomKeyValuePair<int, int>() { Key = x.Key, Value = x.Value }).ToArray();
            var smsJournal = withSmsJournal ? this.smsJournal.
                Select(x => new CustomKeyValuePair<int, int>() { Key = x.Key, Value = x.Value }).ToArray() : null;
            var callsJournal = withCallsJournal ? this.callsJournal.
                Select(x => new CustomKeyValuePair<int, int>() { Key = x.Key, Value = x.Value }).ToArray() : null;
            MemoMobileOperator result = new MemoMobileOperator()
            {
                MaxNumber = this.MaxNumber,
                MinNumber = this.MinNumber,
                CallPricing = this.CallPricing,
                SmsPricing = this.SmsPricing,
                memoSubscribers = memoAccounts,
                Funds = funds,
                smsJournal = smsJournal, 
                callsJournal = callsJournal
            };
            return result;
        }
        
        public bool Equals(MobileOperatorWithMemo mobileOperator) {
            if ((this.MaxNumber != mobileOperator.MaxNumber) || (this.MinNumber != mobileOperator.MinNumber) ||
                (this.CallPricing!= mobileOperator.CallPricing) || (this.SmsPricing!=mobileOperator.SmsPricing))
            {
                return false;
            }
            if (!this.subscribers.Equals<int, MobileAccount>(mobileOperator.subscribers))
            {
                return false;
            }
            if (!this.moneyOnAccount.Equals<int, int>(mobileOperator.moneyOnAccount))
            {
                return false;
            }
            if (!this.smsJournal.Equals<KeyValuePair<int, int>>(mobileOperator.smsJournal))
            {
                return false;
            }
            if (!this.callsJournal.Equals<KeyValuePair<int, int>>(mobileOperator.callsJournal))
            {
                return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            int result = 0;
            result ^= this.MaxNumber ^ this.MinNumber ^ this.CallPricing ^ this.SmsPricing;
            result ^= this.subscribers.GetHashCode<int, MobileAccount>() ^
                this.moneyOnAccount.GetHashCode<int, int>() ^
                this.smsJournal.GetHashCode<KeyValuePair<int, int>>() ^
                this.callsJournal.GetHashCode<KeyValuePair<int, int>>();
            
            return result;
        }
    }
}
