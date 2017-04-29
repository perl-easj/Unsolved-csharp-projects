using System;
using System.Threading;

namespace DiceGame
{
    public class Die
    {
        private int _value;
        private Random _generator;

        public int Value
        {
            get { return _value; }
        }

        public Die()
        {
            // The generator is used for generating random numbers
            _generator = new Random();
            Thread.Sleep(10); // This is needed for magical purposes...
            Roll();  // This puts the die in a well-defined state
        }

        /// <summary>
        /// Roll the die: the value will be set to a random number
        /// between 1 and 6 (both included).
        /// </summary>
        public void Roll()
        {
            _value = _generator.Next(6) + 1;
        }
    }
}