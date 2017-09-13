using System;

namespace SlicesOfPi
{
    class Program
    {
        static void Main(string[] args)
        {
            PiCalcUI.RunPiCalculationAsync();

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
