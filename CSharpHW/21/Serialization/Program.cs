using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;


namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlOperatorInfoSerializer se = new XmlOperatorInfoSerializer();
            Dictionary<int, string> call = new Dictionary<int, string>();
            call.Add(1, "a");
            call.Add(2, "a");
            call.Add(3, "a");
            call.Add(4, "a");
            var arr = call.ToArray();
            MobileOperatorWithMemo Verizon = new MobileOperatorWithMemo(1000);
            MobileAccountWithMemo acc = new MobileAccountWithMemo(Verizon);
            acc.AddNumberToPhoneBook(1, "one");
            acc.AddNumberToPhoneBook(2, "two");
            acc.AddNumberToPhoneBook(3, "three");
            acc.AddNumberToPhoneBook(4, "four");
            MobileAccountWithMemo acc2 = new MobileAccountWithMemo(Verizon);
            MobileAccountWithMemo acc3 = new MobileAccountWithMemo(Verizon);
            acc.MakeCall(acc2.Number);
            acc2.MakeCall(acc.Number);
            acc.MakeCall(acc2.Number);
            acc2.MakeCall(acc.Number);

            acc.MakeCall(acc3.Number);
            acc.MakeCall(acc3.Number);
            acc3.MakeCall(acc.Number);

            Verizon.AddFunds(acc.Number, 100);
            Verizon.AddFunds(acc2.Number, 200);
            Verizon.AddFunds(acc3.Number, 300);

            se.Serialize(Verizon, "C:\\Users\\Udavster\\Documents\\fl2.txt");
            
        }
    }
}
