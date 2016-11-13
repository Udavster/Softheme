using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Serialization
{
    [Serializable, ProtoBuf.ProtoContract]
    //[XmlType(TypeName = "WhateverNameYouLike")]
    public struct CustomKeyValuePair<K, V>
    {
        [ProtoBuf.ProtoMember(1)]
        public K Key
        { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public V Value
        { get; set; }
    }
}
