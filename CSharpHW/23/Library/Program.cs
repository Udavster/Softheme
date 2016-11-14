using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Xml.Linq;
using System.IO;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            XLibDocument document = new XLibDocument();
            document.Open("");
            Console.WriteLine("Standard file opened");
            UIHelpers.Flow(document);
        }
    }

}

