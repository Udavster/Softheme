using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
//using System.Threading.Tasks;


namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Udavster\\Documents\\fl2";
            Console.WriteLine("Binary serializer stats:");
            BinaryOperatorInfoSerializer bos = new BinaryOperatorInfoSerializer();
            TestSerializer(bos, path+".bin", 10);
            TestSerializer(bos, path + ".bin", 10);

            Console.WriteLine("\nJson serializer stats:");
            JsonOperatorInfoSerializer jse = new JsonOperatorInfoSerializer();
            TestSerializer(jse, path + ".json", 10);
            TestSerializer(jse, path + ".json", 10);

            Console.WriteLine("\nXML serializer stats:");
            XmlOperatorInfoSerializer xse = new XmlOperatorInfoSerializer();
            TestSerializer(xse, path + ".xml", 10);
            TestSerializer(xse, path + ".xml", 10);

            Console.WriteLine("\nProtobuf serializer stats:");
            ProtobufOperatorInfoSerializer pse = new ProtobufOperatorInfoSerializer();
            TestSerializer(pse, path + ".proto", 10);
            TestSerializer(pse, path + ".proto", 10);

            Console.ReadLine();
        }
        public static void TestSerializer(IOperatorInfoSerializer serializer, string path, int IterationsNum)
        {
            MobileOperatorWithMemo ATnT = new MobileOperatorWithMemo(maxNumber:10000, silent:true);
            int num = 1000;
            int callNum = 50;
            int smsNum = 20;
            int friendsNum = 50;
            MobileAccountWithMemo[] subscribers = Filler.CreateSubscribersWithMemo(ATnT, num, true);
            Filler.GenerateRandomCalls(subscribers, callNum);
            Filler.GenerateRandomSms(subscribers, smsNum);
            Filler.CreatePhonebooks(subscribers, friendsNum);
            var watch = Stopwatch.StartNew();
            MobileOperatorWithMemo ATnT2 = null;
            for (int i = 0; i < IterationsNum; i++)
            {
                serializer.Serialize(ATnT, path);
                ATnT2 = serializer.Deserialize(path);
            }
            watch.Stop();
            Console.WriteLine("{0}ms",(UInt64)watch.ElapsedMilliseconds);
            Console.WriteLine("Is obj before serialization equal to itself after? {0}", ATnT.Equals(ATnT2));
        }
    }
}
