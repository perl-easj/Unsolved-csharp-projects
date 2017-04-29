using System;

namespace CalculationSimulation
{
    /// <summary>
    /// This class manages the execution of a calculation simulation
    /// </summary>
    class Manager
    {
        /// <summary>
        /// Runs the simulation
        /// </summary>
        public static void Run()
        {
            Simulator theSimulator = new Simulator();
            Random theGenerator = new Random();

            // Runs the simulation 1000 times
            for (int iteration = 0; iteration < 1000; iteration++)
            {
                int x = theGenerator.Next(0, 5);
                int y = theGenerator.Next(0, 5);
                int value = theSimulator.Calculate(x, y);
                Console.WriteLine("Iteration {0:000} :   ({1},{2}) => {3}", iteration, x, y, value);
            }
        }
    }
}
