namespace DiceGame
{
    /// <summary>
    /// This class represents a dice cup containing two dice.
    /// </summary>
    public class DiceCup
    {
        #region Instance fields
        private Die _die1;
        private Die _die2;
        #endregion

        #region Constructor
        public DiceCup()
        {
            // VERY IMPORTANT! When we have instance fields of a class type,
            // we MUST remember to create actual objects in the constructor,
            // that the instance fields can then point to.
            _die1 = new Die();
            _die2 = new Die();
        }
        #endregion

        // Implement a property TotalValue: the sum of 
        // the face values of the dice in the cup
        // public int TotalValue

        // Implement a method Shake: all the dice in the cup should be rolled
        // public void Shake()
    }
}