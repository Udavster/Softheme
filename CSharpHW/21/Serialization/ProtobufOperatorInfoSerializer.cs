using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Serialization
{
    class ProtobufOperatorInfoSerializer:IOperatorInfoSerializer
    {
        public void Serialize(MobileOperatorWithMemo mobileOperator, string path,
        bool withCallsJournal = true, bool withSmsJournal = true)
        {
            MemoMobileOperator memo = mobileOperator.GetMemo(withCallsJournal, withSmsJournal);

            var serializer = ProtoBuf.Serializer.CreateFormatter<MemoMobileOperator>();

            using (Stream stream = File.Create(path))
            {
                ProtoBuf.Serializer.Serialize<MemoMobileOperator>(stream, memo);
            }
        }
        public MobileOperatorWithMemo Deserialize(string path)
        {
            var serializer = ProtoBuf.Serializer.CreateFormatter<MemoMobileOperator>();
            MemoMobileOperator memo;

            using (Stream stream = File.OpenRead(path))
            {
                memo = serializer.Deserialize(stream)
                    as MemoMobileOperator;
            }

            return new MobileOperatorWithMemo(memo);
        }
    }
}
