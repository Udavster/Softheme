using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization
{
    static class CollectionComparer
    {
        public static bool Equals<T,V>(this Dictionary<T,V> a, Dictionary<T,V> b)
        {
            try
            {
                if (a.Count != b.Count)
                {
                    return false;
                }
                foreach (var el in a)
                {
                    if (!b[el.Key].Equals(el.Value))
                    {
                        return false;
                    }
                }
            } catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool Equals<T>(this List<T> a, List<T> b){
            try
            {
                if (a.Count != b.Count)
                {
                    return false;
                }
                var bEnumerator = b.GetEnumerator();
                for (int i = 0; i < a.Count; i++)
                {
                    if (!a[i].Equals(b[i]))
                    {
                        return false;
                    }
                }
            } catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static int GetHashCode<T>(this List<T> a)
        {
            int result = 0;
            for (int i = 0; i < a.Count; i++)
            {
                result ^= a[i].GetHashCode();
            }
            return result;
        }
        public static int GetHashCode<T, V>(this Dictionary<T, V> a)
        {
            int result = 0;
            foreach (var item in a)
            {
                result ^= item.Key.GetHashCode() ^ item.Value.GetHashCode();
            }
            return result;
        }

    }
}
