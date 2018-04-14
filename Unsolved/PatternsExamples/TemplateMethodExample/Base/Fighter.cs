using System;

namespace TemplateMethodExample.Base
{
    public class Fighter
    {
        #region Instance fields
        private static Random _generator = new Random(Guid.NewGuid().GetHashCode());
        private string _name;
        private int _initialHitPoints;
        private int _baseDamage;
        private int _hitPoints;
        #endregion

        #region Constructor
        public Fighter(string name, int initialHitPoints, int baseDamage)
        {
            _name = name;
            _initialHitPoints = initialHitPoints;
            _baseDamage = baseDamage;
            Reset();
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Checks if the Player is dead, defined as having 0 or less hit points...
        /// </summary>
        public bool Stop
        {
            get { return (_hitPoints <= 0); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Reset the Player's state to the original state
        /// </summary>
        public void Reset()
        {
            _hitPoints = _initialHitPoints;
        }

        /// <summary>
        /// Returns the amount of damage points a Player deals in damage.
        /// This damage could then be inflicted on another character.
        /// </summary>
        public int DealDamage()
        {
            return _generator.Next(0, _baseDamage) + 1;
        }

        /// <summary>
        /// The Player receives the amount of damage specified 
        /// by the parameter. The number of hit points left will 
        /// decrease accordingly.
        /// </summary>
        public void ReceiveDamage(int points)
        {
            _hitPoints = _hitPoints - points;
        }
        #endregion
    }
}