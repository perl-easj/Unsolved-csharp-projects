namespace RolePlayV23
{
    class Defender : Character
    {
        public Defender(string name, int hitPoints, int minDamage, int maxDamage) 
            : base(name, hitPoints, minDamage, maxDamage)
        {
        }

        public override void ReceiveDamage(int points)
        {
            int percent = NumberGenerator.Next(0, 100);
            if (percent < 50)
            {
                points = points * 60 / 100;
                _hitPoints = _hitPoints - points;
                string message = Name + " receives " + points + " damage, (REDUCED) and is down to " + _hitPoints + " hit points";
                BattleLog.Save(message);
            }
            else
            {
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
