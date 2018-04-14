using System;
using AdapterExample.ConfigAndTest;

namespace AdapterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            AdapterTest.Run();

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
