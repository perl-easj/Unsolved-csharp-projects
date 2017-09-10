using System;
using System.Threading;

namespace DiceGame
{
    /// <summary>
    /// This class represents a single 6-sided die
    /// </summary>
    public class Die
    {
        #region Instance fields
        private int _faceValue;
        private Random _generator;
        #endregion

        #region Constructor
        public Die()
        {
            _generator = new Random(); // The generator is used for generating random numbers
            Roll();  // This puts the die in a well-defined state
        }
        #endregion

        #region Properties
        public int FaceValue
        {
            get { return _faceValue; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Roll the die: the value will be set to a random number
        /// between 1 and 6 (both included).
        /// </summary>
        public void Roll()
        {
            Thread.Sleep(10); // This is needed for magical purposes...
            _faceValue = _generator.Next(6) + 1;
        } 
        #endregion
    }
}