using System;

namespace NumericalPi
{
    public class PiCalc
    {
        public PiCalc()
        {
        }

        public double Calculate(int iterations)
        {
            int inside = Iterate(iterations);
            return inside * 4.0 / iterations;

            //int insideA = 0;
            //int insideB = 0;
            //int insideC = 0;
            //int insideD = 0;

            //Task taskA = Task.Run(() => { insideA = Iterate(iterations / 4); });
            //Task taskB = Task.Run(() => { insideB = Iterate(iterations / 4); });
            //Task taskC = Task.Run(() => { insideC = Iterate(iterations / 4); });
            //Task taskD = Task.Run(() => { insideD = Iterate(iterations / 4); });

            //Task.WaitAll(taskA, taskB, taskC, taskD);

            //return (insideA + insideB + insideC + insideD) * 4.0 / iterations;
        }

        public int Iterate(int iterations)
        {
            Random _generator = new Random();
            int inside = 0;

            for (int i = 0; i < iterations; i++)
            {
                double x = _generator.NextDouble();
                double y = _generator.NextDouble();

                if (x * x + y * y < 1.0)
                {
                    inside++;
                }
            }

            return inside;
        }
    }
}