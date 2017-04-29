namespace RolePlayV23
{
    class Character
    {
        private string _name;
        protected int _hitPoints;
        protected int _maxHitPoints;
        protected int _minDamage;
        protected int _maxDamage;

        /// <summary>
        /// Name of the Character
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Checks if the Character is dead, defined as having 0 or less hit points...
        /// </summary>
        public bool Dead
        {
            get { return (_hitPoints <= 0); }
        }

        /// <summary>
        /// Create a Character, using references to a random number generator and a battle log
        /// </summary>
        public Character(string name, int hitPoints, int minDamage, int maxDamage)
        {
            _name = name;
            _maxHitPoints = hitPoints;
            _minDamage = minDamage;
            _maxDamage = maxDamage;
            Reset();
        }

        /// <summary>
        /// Reset the Character's state to the original state
        /// </summary>
        public void Reset()
        {
            _hitPoints = _maxHitPoints;
        }

        /// <summary>
        /// Returns the amount of points a Character deals in damage.
        /// This damage could then be received by another character
        /// </summary>
        public virtual int DealDamage()
        {
            int damage = NumberGenerator.Next(_minDamage, _maxDamage);
            string message = Name + " dealt " + damage + " damage!";
            BattleLog.Save(message);
            return damage;
        }

        /// <summary>
        /// The Character receives the amount of damage specified in the parameter.
        /// The number of hit points will decrease accordingly
        /// </summary>
        public virtual void ReceiveDamage(int points)
        {
            _hitPoints = _hitPoints - points;
            string message = Name + " receives " + points + " damage, and is down to " + _hitPoints + " hit points";
            BattleLog.Save(message);

            if (Dead)
            {
                BattleLog.Save(Name + " died!");
            }
        }

        public void LogSurvivor()
        {
            if (!Dead)
            {
                BattleLog.Save(Name + " survived with " + _hitPoints + " hit points left");
            }
        }
    }
}
