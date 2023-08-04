using System;
using System.Collections.Generic; 

namespace testCompanyDirect
{
   static class Program
    {
      static   IResourceData resourceData;
      static  ILocalizationManager localizationManager;
        static Program()
        {
            resourceData = new ResourceData();
            localizationManager = new LocalizationManager();
        }
        static void Main(string[] args)
        {
            var localResource = localizationManager.ReadlocalResource("En")
                                                                   .ToArray();
            while (true)
            {
                try
                {
                   
                    Console.WriteLine("Insert new  Key: ");
                    var Rkey = Console.ReadLine();
                    Console.WriteLine("Insert new Value: ");
                    var Rvalue = Console.ReadLine();

                    resourceData.Func2(ref localResource, int.Parse(Rkey), Rvalue);

                    foreach (var row in localResource)
                        Console.WriteLine(row);

                    Console.WriteLine("press A if you want add new any key to break");

                    if (Console.ReadKey().Key != ConsoleKey.A)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

       

    }
}
