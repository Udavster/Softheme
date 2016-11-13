using System;
using System.Collections.Generic;
using System.Linq;
using MobileNetwork;

namespace Serialization
{
    [Serializable, ProtoBuf.ProtoContract]
    public class MemoMobileOperator
    {
        [ProtoBuf.ProtoMember(1)]
        public int MinNumber;
        [ProtoBuf.ProtoMember(2)]
        public int MaxNumber;
        [ProtoBuf.ProtoMember(3)]
        public MemoMobileAccount[] memoSubscribers;
        [ProtoBuf.ProtoMember(4)]
        public CustomKeyValuePair<int, int>[] callsJournal;
        [ProtoBuf.ProtoMember(5)]
        public CustomKeyValuePair<int, int>[] smsJournal;
        [ProtoBuf.ProtoMember(6)]
        public CustomKeyValuePair<int,int>[] Funds;
        [ProtoBuf.ProtoMember(7)]
        public int CallPricing { get; set; }
        [ProtoBuf.ProtoMember(8)]
        public int SmsPricing { get; set; }
    }
}
