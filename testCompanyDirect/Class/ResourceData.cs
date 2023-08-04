using System;
using System.Collections.Generic; 

namespace testCompanyDirect
{
    class ResourceData:IResourceData
    { 
         public int Func1(KeyValuePair<int, string>[] a, int low, int high, int key)
        {
            int middle = low + ((high - low) / 2);

            if (low == high)
                return low;

            if (key > a[middle].Key)
                return Func1(a, middle + 1, high, key);

            return Func1(a, low, middle, key);
        }

        public  void Func2(ref KeyValuePair<int, string>[] a, int key, string value)
        {
            int pos;
            KeyValuePair<int, string> keyValuePair;

            if (a.Length == 0)
            {
                Array.Resize(ref a, 1);
                keyValuePair = new KeyValuePair<int, string>(key, value);
                a[0] = keyValuePair;
                return;
            }

            if (key < a[0].Key)
                pos = 0;
            else if (key > a[a.Length - 1].Key)
                pos = a.Length;
            else
                pos = Func1(a, 0, a.Length - 1, key);

            Array.Resize(ref a, a.Length + 1);

            for (int i = a.Length - 1; i > pos; i--)
                a[i] = a[i - 1];

            keyValuePair = new KeyValuePair<int, string>(key, value);
            a[pos] = keyValuePair;
        }
    }
}
