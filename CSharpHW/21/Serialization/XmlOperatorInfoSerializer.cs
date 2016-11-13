using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections;
//using System.Linq;

using MobileNetwork;


namespace Serialization
{
    class XmlOperatorInfoSerializer : IOperatorInfoSerializer
    {
        public void Serialize(MobileOperatorWithMemo mobileOperator, string path,
            bool withCallsJournal = true, bool withSmsJournal = true)
        {
            MemoMobileOperator memo = mobileOperator.GetMemo(withCallsJournal, withSmsJournal);

            XmlSerializer serializer = new XmlSerializer(memo.GetType());

            using (StreamWriter streamWriter = File.CreateText(
                path))
            {
                serializer.Serialize(streamWriter, memo);
            }

        }
        public MobileOperatorWithMemo Deserialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MemoMobileOperator));
            MemoMobileOperator memo;

            using (StreamReader streamReader = File.OpenText(
                path))
            {
                memo = serializer.Deserialize(streamReader)
                    as MemoMobileOperator;
            }

            return new MobileOperatorWithMemo(memo);
        }
    }
}
