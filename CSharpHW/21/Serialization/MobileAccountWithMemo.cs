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
            if (memo.phoneBook == null)
            {
                return;
            }
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
        public bool Equals(MobileAccountWithMemo mobileAccount)
        {
            if (this.Number != mobileAccount.Number)
            {
                return false;
            }
            return this.phoneBook.Equals<int, string>(mobileAccount.phoneBook);
        }
        public override bool Equals(object obj)
        {
            var item = obj as MobileAccountWithMemo;
            if (item == null)
            {
                return false;
            }
            return Equals(item);
        }
        public override int GetHashCode()
        {
            return this.Number ^ this.phoneBook.GetHashCode<int, string>();
        }
    }
}
