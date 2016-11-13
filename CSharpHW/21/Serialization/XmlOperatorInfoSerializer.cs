using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections;
//using System.Linq;

using MobileNetwork;


namespace Serialization
{
    class XmlOperatorInfoSerializer: OperatorInfoSerializer
    {
        public void Serialize(MobileOperatorWithMemo mobileOperator, string path)
        {
            MemoMobileOperator memo = mobileOperator.GetMemo(true,true);

            XmlSerializer serializer = new XmlSerializer(memo.GetType());

            using (StreamWriter streamWriter = File.CreateText(
                path))
            {
                serializer.Serialize(streamWriter, memo);
            }
            
        }
        public void Deserialize(string path)
        {
            //using (StreamReader streamReader = File.OpenText(
            //    path))
            //{
            //    memo = serializer.Deserialize(streamReader)
            //        as MemoMobileAccount?;
            //}
            //MobileAccountWithMemo m = new MobileAccountWithMemo(Verizon, memo.Value);
        }
    }
}
