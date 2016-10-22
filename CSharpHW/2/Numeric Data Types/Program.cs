using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTypes {
    class Program {
        static void Main(string[] args) {
            FormatTypeInfo(typeof(sbyte), sbyte.MinValue, sbyte.MaxValue, default(sbyte));
            FormatTypeInfo(typeof(byte), byte.MinValue, byte.MaxValue, default(byte));
            FormatTypeInfo(typeof(short), short.MinValue, short.MaxValue, default(short));
            FormatTypeInfo(typeof(ushort), ushort.MinValue, ushort.MaxValue, default(ushort));
            FormatTypeInfo(typeof(int), int.MinValue, int.MaxValue, default(int));
            FormatTypeInfo(typeof(uint), uint.MinValue, uint.MaxValue, default(uint));
            FormatTypeInfo(typeof(long), long.MinValue, long.MaxValue, default(long));
            FormatTypeInfo(typeof(ulong), ulong.MinValue, ulong.MaxValue, default(ulong));
            FormatTypeInfo(typeof(float), float.MinValue, float.MaxValue, default(float));
            FormatTypeInfo(typeof(decimal), decimal.MinValue, decimal.MaxValue, default(decimal));
            FormatTypeInfo(typeof(double), double.MinValue, double.MaxValue, default(double));

            Console.ReadLine();
        }

        static void FormatTypeInfo(Type type, object minValue, object maxValue, object Default) {
            Console.Write("{0} has MinValue of ", type.FullName);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(minValue.ToString());
            Console.ResetColor();
            Console.Write(", MaxValue of ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write( maxValue.ToString());
            Console.ResetColor();
            Console.Write(", default value of ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Default.ToString());
            Console.ResetColor();
            Console.WriteLine();
        }


    }


}
