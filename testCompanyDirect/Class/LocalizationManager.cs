using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using testCompanyDirect.Enum;

namespace testCompanyDirect
{
    class LocalizationManager: ILocalizationManager
    {
        char separator = ';';
        string file = @"localRsourceTest.csv";
        public bool RegisterSource(KeyValuePair<int, string>[] a, EnumCultureID cultureInfoID)
        {                    
            StringBuilder output = new StringBuilder();
            try
            {
                String[] headings = { "Key", "Value", "CultureID" };
                output.AppendLine(string.Join(separator.ToString(), headings));
               var allDataResource= ReadlocalResource( EnumCultureID.All);

                 
                foreach (var newResource in a)
                {
                    string newLine = string.Format("{0}, {1}, {2}", newResource.Key, newResource.Value, cultureInfoID);
                    output.AppendLine(string.Join(separator.ToString(), newLine));
                }              
                
                File.AppendAllText(file, output.ToString());
            }
            catch (Exception)
            {
                return false;
            }
            return true;            
        }
       public List<KeyValuePair<int, string>> ReadlocalResource(EnumCultureID cultureInfoID) 
        {
           List< KeyValuePair<int, string>>  resourceValues=new List<KeyValuePair<int, string>>();
            using (var reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(separator);

                    if (cultureInfoID == EnumCultureID.All)
                        resourceValues.Add(new KeyValuePair<int, string>
                                   (int.Parse(values[0]), values[1]));
                    else if (values[2] == cultureInfoID.ToString())
                        resourceValues.Add(new KeyValuePair<int, string>
                            (int.Parse(values[0]), values[1]));            
                }
                return resourceValues;
            }
        }

        public List<KeyValuePair<int, string>> GetString(string stringID, EnumCultureID cultureInfoID)
        {
            var allDataResource = ReadlocalResource(cultureInfoID);
            List<KeyValuePair<int, string>> resourceValues = new List<KeyValuePair<int, string>>();
            foreach (var element in allDataResource)
            {
                if (stringID == element.Value)
                    resourceValues.Add(element);
            }
            return allDataResource;
        }
    }
}
