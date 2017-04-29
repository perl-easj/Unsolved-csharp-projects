namespace DiceGame
{
    public class DiceCup
    {
        private Die die1;
        private Die die2;

        public DiceCup()
        {
            // VERY IMPORTANT! When we have instance fields of a class type,
            // we MUST remember to create actual objects in the constructor,
            // that the instance fields can then point to.
            die1 = new Die();
            die2 = new Die();
        }

        // Implement a property TotalValue: the sum of the values of the dice in the cup
        // public int TotalValue


        // Implement a method Shake: all the dice in the cup should be rolled
        // public void Shake()
    }
}