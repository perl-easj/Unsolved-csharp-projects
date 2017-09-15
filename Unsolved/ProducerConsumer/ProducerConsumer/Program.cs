using System;

#pragma warning disable 4014

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sets up and starts a scenario
            Scenario theScenario = new Scenario(40, 20, 40, 100, 80, Reporter<Data>.ReportMode.verbose);
            theScenario.RunAsync();

            Console.WriteLine("Press any key to abort the run...");
            Console.ReadKey();
        }
    }
}
