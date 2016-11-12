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

            se.Serialize("C:\\Users\\Udavster\\Documents\\fl2.txt");
            
        }
    }
}
