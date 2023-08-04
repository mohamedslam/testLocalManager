using System;
using testCompanyDirect.Enum;

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
             EnumCultureID enumCultureID = EnumCultureID.En;
            while (true)
            {
                try
                {
                    Console.WriteLine("Press G to G to find String or N to add New ");
                    var keyPress = Console.ReadKey().Key;
                    if (keyPress == ConsoleKey.G)
                    {
                        Console.WriteLine("insert and string to find: ");

                       var rst= localizationManager.GetString(Console.ReadLine(), EnumCultureID.All);
                        foreach (var elem in rst)
                            Console.WriteLine(elem);
                    }
                    else if (keyPress == ConsoleKey.N)
                    {
                        Console.WriteLine("Insert new  Key: ");
                        var Rkey = Console.ReadLine();
                        Console.WriteLine("Insert new Value: ");
                        var Rvalue = Console.ReadLine();
                        Console.WriteLine("Insert new Calture (En or Ru): ");
                        var Rclu = Console.ReadLine();

                        //need to refactory
                      

                        if (Rclu == "Ru")
                            enumCultureID = EnumCultureID.Ru;
                        else if (Rclu == "Ru")
                            enumCultureID = EnumCultureID.En;

                        var localResource = localizationManager.ReadlocalResource(enumCultureID)
                                                                          .ToArray();

                        resourceData.Func2(ref localResource, int.Parse(Rkey), Rvalue);

                        localizationManager.RegisterSource(localResource, enumCultureID);


                        foreach (var row in localResource)
                            Console.WriteLine(row);
                    }
                    Console.WriteLine("press Any if you want to Main or B key to break");

                    if (Console.ReadKey().Key != ConsoleKey.B)
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
