using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testCompanyDirect
{
      interface ILocalizationManager
    {
        bool RegisterSource(int key, string value, string cultureInfoID);
        void GetString(ref KeyValuePair<int, string>[] stringID, string cultureInfoID);
        List<KeyValuePair<int, string>> ReadlocalResource(string cultureInfoID);
    }
}
