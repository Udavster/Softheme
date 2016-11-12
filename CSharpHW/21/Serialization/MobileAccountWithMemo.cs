using System;
using System.Collections.Generic;
using System.Linq;
using MobileNetwork;

namespace Serialization
{
    class MobileAccountWithMemo : MobileAccount
    {
        public MobileAccountWithMemo(MobileOperator mobileOperator, MemoMobileAccount memo) :
            base(mobileOperator, memo.Number)
        {
            this.phoneBook = new Dictionary<int, string>();
            for (int i = 0; i < memo.phoneBook.Length; i++)
            {
                this.phoneBook.Add(memo.phoneBook[i].Key, memo.phoneBook[i].Value);
            }
        }
        public MobileAccountWithMemo(MobileOperator mobileOperator, int number) :
            base(mobileOperator, number) { }
        public MobileAccountWithMemo(MobileOperator mobileOperator) :
            base(mobileOperator) { }
        public MemoMobileAccount GetMemo()
        {
            var phoneBookMemo = new CustomKeyValuePair<int,string>[this.phoneBook.Count];
            int i = 0;
            foreach (var item in phoneBook)
            {
                phoneBookMemo[i] = new CustomKeyValuePair<int, string>(){
                    Key = item.Key,
                    Value = item.Value
                };
                i++;
            }
            return new MemoMobileAccount()
            {
                Number = this.Number,
                phoneBook = phoneBookMemo
            };
        }
    }
}
