using System;
using System.Collections.Generic;
using System.Linq;
using MobileNetwork;

namespace Serialization
{
    public class MemoMobileOperator
    {
        public int MinNumber;
        public int MaxNumber;
        public MemoMobileAccount[] memoSubscribers;
        public CustomKeyValuePair<int, int>[] callsJournal;
        public CustomKeyValuePair<int, int>[] smsJournal;
        public CustomKeyValuePair<int,int>[] Funds;
        public int CallPricing { get; set; }
        public int SmsPricing { get; set; }
    }
}
