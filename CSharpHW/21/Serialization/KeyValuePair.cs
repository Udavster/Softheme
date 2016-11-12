using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Serialization
{
    [Serializable]
    [XmlType(TypeName = "WhateverNameYouLike")]
    public struct CustomKeyValuePair<K, V>
    {
        public K Key
        { get; set; }

        public V Value
        { get; set; }
        public static implicit operator CustomKeyValuePair<K,V>(System.Collections.Generic.KeyValuePair<K, V> kvp)
        {
            return new CustomKeyValuePair<K, V>()
            {
                Key = kvp.Key,
                Value = kvp.Value
            };
        }
       
    }
}
