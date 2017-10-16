using System;

namespace RolePlayV30.BattleManagement
{
    /// <summary>
    /// This class is for generation of random numbers within a given interval
    /// </summary>
    public static class NumberGenerator
    {
        private static Random _generator = new Random();

        /// <summary>
        /// Returns a random number in the interval between the values of 
        /// "min" and "max"
        /// </summary>
        public static int Next(int min, int max)
        {
            int value = min + _generator.Next(max - min);
            return value;
        }
    }
}