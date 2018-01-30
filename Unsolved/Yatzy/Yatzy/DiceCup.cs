using System.Collections.Generic;

namespace Yatzy
{
    /// <summary>
    /// A DiceCup is a collection of dice, which can be rolled
    /// by "shaking" the dice cup.
    /// </summary>
    public class DiceCup
    {
        List<Die> _dice;
        private int _noOfFaces;

        public DiceCup(int numberOfDice, int noOfFaces)
        {
            _dice = new List<Die>();
            _noOfFaces = noOfFaces;

            // Add the specified number of dice to the cup.
            // All dice have the same number of faces.
            for (int i = 0; i < numberOfDice; i++)
            {
                _dice.Add(new Die(noOfFaces));
            }
        }

        /// <summary>
        /// Shake the dice cup, i.e. roll all dice in the cup.
        /// </summary>
        public void Shake()
        {
            foreach (Die d in _dice)
            {
                d.RollDie();
            }
        }

        /// <summary>
        /// Returns the dice values as a simple list.
        /// </summary>
        public List<int> DiceValues
        {
            get
            {
                List<int> diceValues = new List<int>();

                foreach (Die d in _dice)
                {
                    diceValues.Add(d.Value);
                }

                return diceValues;
            }
        }

        /// <summary>
        /// Returns the dice values as (value, count) pairs.
        /// The dice values 2, 3, 6, 6, 2, 6
        /// will be returned as
        /// ((1,0), (2,2), (3,1), (4,0), (5,0), (6,3))
        /// </summary>
        public Dictionary<int, int> DiceCountByValue
        {
            get
            {
                Dictionary<int, int> diceCountByValue = new Dictionary<int, int>();

                for (int i = 1; i <= _noOfFaces; i++)
                {
                    diceCountByValue.Add(i,0);
                }

                foreach (Die d in _dice)
                {
                    diceCountByValue[d.Value]++;
                }

                return diceCountByValue;
            }
        }

        /// <summary>
        /// Returns a reasonably readable string 
        /// representation of the values of the dice. 
        /// </summary>
        public override string ToString()
        {
            string diceStr = "Dice show :  ";

            foreach (Die d in _dice)
            {
                diceStr += $" {d.Value} ";
            }

            return diceStr;
        }
    }
}