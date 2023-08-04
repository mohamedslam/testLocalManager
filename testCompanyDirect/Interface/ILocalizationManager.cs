using System.Collections.Generic;
using testCompanyDirect.Enum;

namespace testCompanyDirect
{
    interface ILocalizationManager
    {
        bool RegisterSource( KeyValuePair<int, string>[] a, EnumCultureID cultureInfoID);
        List<KeyValuePair<int, string>> GetString(string  stringID, EnumCultureID cultureInfoID);
        List<KeyValuePair<int, string>> ReadlocalResource(EnumCultureID cultureInfoID);
    }
}
