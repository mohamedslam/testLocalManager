using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace testCompanyDirect
{
    class LocalizationManager: ILocalizationManager
    {
        char separator = ';';
        string file = @"localRsourceTest.csv";
        public bool RegisterSource(int key, string value,string cultureInfoID)
        {                    
            try
            {
                StringBuilder output = new StringBuilder();
                string newLine = string.Format("{0}, {1}, {2}", key, value, cultureInfoID);
                output.AppendLine(string.Join(separator.ToString(), newLine));  
                File.AppendAllText(file, output.ToString());
            }
            catch (Exception)
            {
                return false;
            }
            return true;            
        }
       public List<KeyValuePair<int, string>> ReadlocalResource(string cultureInfoID) 
        {
           List< KeyValuePair<int, string>>  resourceValues=new List<KeyValuePair<int, string>>();
            using (var reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(separator);
 
                    if (values[2] == cultureInfoID)
                    {
                        resourceValues.Add(new KeyValuePair<int, string>
                            (int.Parse(values[0]), values[1]));
                    }
 
                }
                return resourceValues;
            }
        }

        public void GetString(ref KeyValuePair<int, string>[] stringID,string  cultureInfoID)
        { 
          CultureInfo  cultureInfo = String.IsNullOrEmpty(cultureInfoID)
                        ? CultureInfo.InvariantCulture // Or use other default
                        : new CultureInfo(cultureInfoID);
        }
    }
}
