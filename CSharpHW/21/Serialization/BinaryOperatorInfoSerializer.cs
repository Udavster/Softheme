using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Serialization
{
    class BinaryOperatorInfoSerializer:IOperatorInfoSerializer
    {
        public void Serialize(MobileOperatorWithMemo mobileOperator, string path,
            bool withCallsJournal = true, bool withSmsJournal = true)
        {
            MemoMobileOperator memo = mobileOperator.GetMemo(withCallsJournal, withSmsJournal);

            BinaryFormatter serializer = new BinaryFormatter();

            using (Stream streamWriter = File.Create(path))
            {
                serializer.Serialize(streamWriter, memo);
            }

        }
        public MobileOperatorWithMemo Deserialize(string path)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoMobileOperator memo;

            using (Stream streamReader = File.OpenRead(path))
            {
                memo = serializer.Deserialize(streamReader)
                    as MemoMobileOperator;
            }

            return new MobileOperatorWithMemo(memo);
        }
    }
}
