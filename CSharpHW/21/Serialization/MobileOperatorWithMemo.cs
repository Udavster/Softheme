using System;
using System.Collections.Generic;
using System.Linq;
using MobileNetwork;

namespace Serialization
{
    class MobileOperatorWithMemo: MobileOperator
    {
        public MobileOperatorWithMemo(int maxNumber, int minNumber = 0, int callPricing = 0, int smsPricing = 0):
            base(maxNumber, minNumber, callPricing, smsPricing) { }
        public MobileOperatorWithMemo(MemoMobileOperator memo) :
            base(memo.MaxNumber, memo.MinNumber, memo.CallPricing, memo.SmsPricing) { }
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
    }
}
