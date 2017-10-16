using RolePlayV30.BattleManagement;

namespace RolePlayV30.Characters
{
    /// <summary>
    /// This class represents the "damager" character type.
    /// </summary>
    public class Damager : Character
    {
        public Damager(string name, int hitPoints, int minDamage, int maxDamage)
            : base(name, hitPoints, minDamage, maxDamage)
        {
        }

        public override int DealDamage()
        {
            int percentRoll = NumberGenerator.Next(0, 100);
            int damage = NumberGenerator.Next(_minDamage, _maxDamage);

            if (percentRoll < 40)
            {
                // Increased damage              
                damage = damage * 2;
                string message = Name + " dealt " + damage + " damage! (INCREASED)";
                BattleLog.Save(message);
            }
            else
            {
                // Normal damage
                string message = Name + " dealt " + damage + " damage!";
                BattleLog.Save(message);
            }

            return damage;
        }
    }
}