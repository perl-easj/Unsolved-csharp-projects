using System;
using CoRExample.Test;

namespace CoRExample
{
    class Program
    {
        static void Main(string[] args)
        {
            CoRTest.Run();

            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
