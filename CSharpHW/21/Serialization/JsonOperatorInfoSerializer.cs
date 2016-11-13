using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Serialization.
using System.Runtime.Serialization.Json;
using System.IO;

namespace Serialization
{
    class JsonOperatorInfoSerializer:IOperatorInfoSerializer
    {
        public void Serialize(MobileOperatorWithMemo mobileOperator, string path,
           bool withCallsJournal = true, bool withSmsJournal = true)
        {
            MemoMobileOperator memo = mobileOperator.GetMemo(withCallsJournal, withSmsJournal);

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(memo.GetType());

            using (Stream stream = File.Create(path))
            {
                serializer.WriteObject(stream, memo);
            }

        }
        public MobileOperatorWithMemo Deserialize(string path)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MemoMobileOperator));
            MemoMobileOperator memo;

            using (Stream stream = File.OpenRead(path))
            {
                memo = serializer.ReadObject(stream)
                    as MemoMobileOperator;
            }

            return new MobileOperatorWithMemo(memo);
        }
    }
}
