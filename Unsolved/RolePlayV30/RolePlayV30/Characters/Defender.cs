using RolePlayV30.BattleManagement;

namespace RolePlayV30.Characters
{
    /// <summary>
    /// This class represents the "defender" character type.
    /// </summary>
    public class Defender : Character
    {
        public Defender(string name, int hitPoints, int minDamage, int maxDamage)
            : base(name, hitPoints, minDamage, maxDamage)
        {
        }

        public override void ReceiveDamage(int points)
        {
            int percentRoll = NumberGenerator.Next(0, 100);

            if (percentRoll < 50)
            {
                // Reduced damage
                int reducedPoints = points * 60 / 100; // Reduce by 40 %
                _hitPoints = _hitPoints - reducedPoints;
                string message = Name + " receives " + reducedPoints + " damage (REDUCED), and is down to " + _hitPoints + " hit points";
                BattleLog.Save(message);
            }
            else
            {
                // Normal damage
                _hitPoints = _hitPoints - points;
                string message = Name + " receives " + points + " damage, and is down to " + _hitPoints + " hit points";
                BattleLog.Save(message);
            }

            if (Dead)
            {
                BattleLog.Save(Name + " died!");
            }
        }
    }
}