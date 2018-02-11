using System;
using System.Threading.Tasks;

namespace SlicesOfPi
{
    /// <summary>
    /// This class implements a very simplistic UI for interacting
    /// with a running calculation of Pi.
    /// </summary>
    public class PiCalcUI
    {
        #region Traditional version
        // Traditional version of calculation, without 
        // and asynchronous programming
        public static void RunPiCalculation()
        {
            // Setup calculator and data objects
            PiCalcAlgorithm calc = new PiCalcAlgorithm();
            PiCalcData data = new PiCalcData();

            // Run the main loop
            MainUILoop(calc, data);

            // Report result
            Console.WriteLine($"Final value for pi : {data.Pi}");
            Console.WriteLine($"Found after {data.Iterations} iterations");
        }

        // Main UI loop for the traditional version
        private static void MainUILoop(PiCalcAlgorithm calc, PiCalcData data)
        {
            // Keep doing this until the user quits.
            while (!data.Quit)
            {
                // Prompt user for input
                Console.Write("Enter p (pi value), d (do more iterations), i (iterations) or q (quit) : ");
                string userInput = Console.ReadLine();

                // Sanity check for input
                if (string.IsNullOrEmpty(userInput)) { continue; }

                // Process user input
                if (userInput.Equals("p")) // Pi value
                {
                    double diffPercent = Math.Abs((Math.PI - data.Pi) * 100.0 / Math.PI);
                    Console.WriteLine($"Current value for pi : {data.Pi} ({diffPercent} % diff.)");
                }
                else if (userInput.Equals("d")) // Do more iterations
                {
                    Console.Write("Enter number of iterations to do : ");
                    string iterationsStr = Console.ReadLine();
                    if (Int32.TryParse(iterationsStr, out var iterationsInSlice) && iterationsInSlice > 0)
                    {
                        double partialPi = calc.Calculate(iterationsInSlice);
                        Console.WriteLine($"Did {iterationsInSlice} additional iterations");
                        data.Pi = (data.Pi * data.Iterations + partialPi * iterationsInSlice) / (data.Iterations + iterationsInSlice);
                        data.Iterations += iterationsInSlice;
                    }
                }
                else if (userInput.Equals("i")) // Iterations so far
                {
                    Console.WriteLine($"Iterations so far : {data.Iterations}");
                }
                else if (userInput.Equals("q")) // Quit
                {
                    data.Quit = true;
                }
            }
        }
        #endregion

        #region Asynchronous version
        // Asynchronous version of calculation
        public static async void RunPiCalculationAsync()
        {
            // Setup calculator and data objects
            PiCalcAlgorithm calc = new PiCalcAlgorithm();
            PiCalcData data = new PiCalcData();

            // This is where the magic happens...
            Task task = calc.CalculateAsync(data);
            MainUILoopForAsync(data);
            await task;

            // Report result
            Console.WriteLine($"Final value for pi : {data.Pi}");
            Console.WriteLine($"Found after {data.Iterations} iterations");
        }

        // Main UI loop for the asynchronous version
        private static void MainUILoopForAsync(PiCalcData data)
        {
            // Keep doing this until the user quits.
            while (!data.Quit)
            {
                // Prompt user for input
                Console.Write("Enter p (pi value), i (iterations) or q (quit) : ");
                string userInput = Console.ReadLine();

                // Sanity check for input
                if (string.IsNullOrEmpty(userInput)) { continue; }

                // Process user input
                if (userInput.Equals("p"))
                {
                    double diffPercent = Math.Abs((Math.PI - data.Pi) * 100.0 / Math.PI);
                    Console.WriteLine($"Current value for pi : {data.Pi} ({diffPercent} % diff.)");
                }
                else if (userInput.Equals("i"))
                {
                    Console.WriteLine($"Iterations so far : {data.Iterations}");
                }
                else if (userInput.Equals("q"))
                {
                    data.Quit = true;
                }
            }
        } 
        #endregion
    }
}