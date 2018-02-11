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
        /// Calculates an approximate value of Pi. The algorithm is
        /// incremental, i.e. the approximate value gets better and
        /// better, the longer the algorithm runs.
        /// Note that this version does NOT use async.
        /// </summary>
        /// <param name="iterations">Number of iterations to perform</param>
        /// <returns>Final value of Pi</returns>
        public double Calculate(int iterations)
        {
            // Setup 
            Random generator = new Random();
            int insideUnitCircle = 0;

            // Main loop in algorithm
            for (long i = 1; i <= iterations; i++)
            {
                insideUnitCircle += RandomPointWithinUnitCircle(generator) ? 1 : 0;
            }

            // Return final value of Pi 
            return insideUnitCircle * 4.0 / iterations;
        }

        /// <summary>
        /// Calculates an approximate value of Pi. The algorithm is
        /// incremental, i.e. the approximate value get better and
        /// better, the longer the algorithm runs.
        /// Note that this version of the algorithm is async.
        /// </summary>
        /// <param name="data">Reference to data coordination object</param>
        /// <returns>Final value of Pi, if algorithm is allowed to run to completion</returns>
        public async Task CalculateAsync(PiCalcData data)
        {
            // Setup 
            Random generator = new Random();
            int insideUnitCircle = 0;

            // Main loop in algorithm is started as a new Task.
            // Note that the task is awaited, i.e. the flow-of-execution
            // returns to the caller of CalculateAsync.
            await Task.Run(() =>
            {
                long iterations = 0;
                while (!data.Quit)
                {
                    insideUnitCircle += RandomPointWithinUnitCircle(generator) ? 1 : 0;
                    iterations++;

                    // Update data object
                    data.Pi = insideUnitCircle * 4.0 / iterations;
                    data.Iterations = iterations;
                }
            });
        }

        /// <summary>
        /// Generates a random point within the unit square,
        /// and returns whether or not the point was within
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