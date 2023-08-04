using System;
using System.Collections.Generic;
using System.Globalization;
 
namespace testCompanyDirect
{
    interface IResourceData
    {
        int Func1(KeyValuePair<int, string>[] a, int low, int high, int key);
        void Func2(ref KeyValuePair<int, string>[] a, int key, string value);
    }
}
