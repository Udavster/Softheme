using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public struct MemoMobileAccount
    {
        public int Number;
        public CustomKeyValuePair<int,string>[] phoneBook;
    }
}
