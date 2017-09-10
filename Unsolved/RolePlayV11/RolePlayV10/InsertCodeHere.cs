using System;

namespace RolePlayV11
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            Warrior firstWarrior = new Warrior("Ragnar");
            Warrior secondWarrior = new Warrior("Lagertha");

            Console.WriteLine($"{firstWarrior.Name} is level {firstWarrior.Level}");
            Console.WriteLine($"{secondWarrior.Name} is level {secondWarrior.Level}");

            // The LAST line of code should be ABOVE this line
        }
    }
}