using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NumericalPi
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            PiCalc calculator = new PiCalc();
            
            watch.Start();
            Console.WriteLine("Started");
            double numPi = calculator.Calculate(100000000);
            Console.WriteLine("Done");
            watch.Stop();

            Console.WriteLine($"Numeric PI = {numPi:0.000000}");
            Console.WriteLine($"Real PI    = {Math.PI:0.000000}");
            Console.WriteLine($"Took {watch.ElapsedMilliseconds} milliSecs");
            Console.ReadKey();
        }
    }
}
