using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    struct KeyValuePair<T, U>
    {
        public T Key { get; private set; }
        public U Value { get; set; }
        public KeyValuePair(T key, U value):this()
        {
            this.Key = key;
            this.Value = value;
        }

        public override string ToString()
        {
            return String.Format("[{0}=>{1}]", Key.ToString(), Value.ToString());
        }
    }
}
