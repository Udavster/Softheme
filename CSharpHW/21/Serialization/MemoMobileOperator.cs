using System;
using System.Collections.Generic;
using System.Linq;
using MobileNetwork;

namespace Serialization
{
    class MemoMobileOperator
    {
        public int MinNumber;
        public int MaxNumber;
        public Random numberGenerator;
        public List<MemoMobileAccount> subscribers;
        public List<CustomKeyValuePair<int, int>> callsJournal;
        public List<CustomKeyValuePair<int, int>> smsJournal;
        public CustomKeyValuePair<int,int>[] moneyOnAccount;
        public int CallPricing { get; set; }
        public int SmsPricing { get; set; }
    }
}
