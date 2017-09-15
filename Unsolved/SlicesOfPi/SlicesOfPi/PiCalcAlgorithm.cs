using System;
using System.Threading.Tasks;

namespace SlicesOfPi
{
    /// <summary>
    /// This class implements the algorithm for calculating
    /// an approximate value of Pi.
    /// </summary>
    public class PiCalcAlgorithm
    {
        /// <summary>
        /// Calculates approximate value of Pi. The algorithm is
        /// incremental, i.e. the approximate value get better and
        /// better, the longer the algorithm runs.
        /// Note that this version does NOT use async.
        /// </summary>
        /// <param name="iterations">Number of iterations to perform</param>
        /// <returns>Final value of Pi</returns>
        public double Calculate(int iterations)
        {
            // Setup 
            Random _generator = new Random();
            int insideUnitCircle = 0;

            // Main loop in algorithm
            for (long i = 1; i <= iterations; i++)
            {
                insideUnitCircle += RandomPointWithinUnitCircle(_generator) ? 1 : 0;
            }

            // Return final value of Pi 
            return insideUnitCircle * 4.0 / iterations;
        }

        /// <summary>
        /// Calculates approximate value of Pi. The algorithm is
        /// incremental, i.e. the approximate value get better and
        /// better, the longer the algorithm runs.
        /// Note that this version of the algorithm is async.
        /// </summary>
        /// <param name="data">Reference to data coordination object</param>
        /// <returns>Final value of Pi, if algorithm is allowed to run to completion</returns>
        public async Task<double> CalculateAsync(PiCalcData data)
        {
            // Setup 
            Random _generator = new Random();
            int insideUnitCircle = 0;
            double piCurrent = 0.0;

            // Main loop in algorithm is started as a new Task
            // Note that the task is awaited, i.e. the flow-of-execution
            // returns to the caller of CalculateAsync.
            await Task.Run(() =>
            {
                for (long i = 1; i <= 1000000000000 && !data.Quit; i++)
                {
                    insideUnitCircle += RandomPointWithinUnitCircle(_generator) ? 1 : 0;

                    // Update data object
                    piCurrent = insideUnitCircle * 4.0 / i;
                    data.Pi = piCurrent;
                    data.Iterations = i;
                }
            });

            // Execution only reaches this point, if the user 
            // did not interrupt the calculation.
            return piCurrent;
        }

        /// <summary>
        /// Generates a random point within the unit square,
        /// and return whether or not the point was within
        /// the unit circle
        /// </summary>
        private bool RandomPointWithinUnitCircle(Random generator)
        {
            // Create random point inside the unit square
            double x = generator.NextDouble();
            double y = generator.NextDouble();

            return (x * x + y * y < 1.0);
        }
    }
}