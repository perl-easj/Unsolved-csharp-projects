using System.Collections.Generic;

namespace Yatzy.Evaluators
{
    /// <summary>
    /// Implementation of the "One pair" entry in Yatzy.
    /// </summary>
    public class OnePairEvaluator : IDiceEvaluator
    {
        /// <summary>
        /// The value of "One pair" is the
        /// highest sum of the values of two
        /// dice showing the same face, e.g. 5,5.
        /// </summary>
        public int Evaluate(Dictionary<int, int> diceCountByValue)
        {
            int score = 0;

            foreach (var dieCount in diceCountByValue)
            {
                // If this is a pair (first condition)
                // with better score than seen so far (second condition)
                if ((dieCount.Value >= 2) && (dieCount.Key * 2 > score))
                {
                    score = dieCount.Key * 2;
                }
            }

            return score;
        }
    }
}