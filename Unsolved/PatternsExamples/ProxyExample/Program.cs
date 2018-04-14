using System;
using ProxyExample.ConfigAndTest;
using ProxyExample.Helpers;

namespace ProxyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyTest.Run();

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
