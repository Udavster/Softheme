using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable, ProtoBuf.ProtoContract]
    public struct MemoMobileAccount
    {
        [ProtoBuf.ProtoMember(1)]
        public int Number;
        [ProtoBuf.ProtoMember(2)]
        public CustomKeyValuePair<int,string>[] phoneBook;
    }
}
