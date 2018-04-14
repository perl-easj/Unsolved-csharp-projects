using System;
using TemplateMethodExample.ConfigAndTest;

namespace TemplateMethodExample
{
    class Program
    {
        static void Main(string[] args)
        {
            TemplateMethodTest.Run();

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
