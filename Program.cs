using System.Collections.Generic;
using System.Diagnostics;

namespace Playground;
class PlaygroundMain
{
    public static void Main(string[] args)
    {

        do
        {
           

          //  Playground.ClassFibonacci.RunFibs(44);  
            Playground.ClassArrayAndList.ExecuteFunctions(); 


        } while(RunAgain());


      
    }
     


    private static bool RunAgain()
    {
        Console.WriteLine("Run again (Y/N)?");
        var inputText = Console.ReadLine();
        if (inputText.ToUpper() != "Y")
        {
            Console.WriteLine("Bye bye...");
            return false;
        }
        return true;
    }

}

