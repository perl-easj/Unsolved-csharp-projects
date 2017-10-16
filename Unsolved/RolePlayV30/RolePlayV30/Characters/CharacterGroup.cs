using System.Collections.Generic;
using RolePlayV30.Calculators.Base;

namespace RolePlayV30.Characters
{
    /// <summary>
    /// This class represents a group of game characters
    /// </summary>
    public class CharacterGroup
    {
        #region Instance fields
        private List<Character> _group;
        private string _groupName;

        private AggregationCalculation<bool, bool> _deadCalc;
        private AggregationCalculation<int, int> _dealDamageCalc;
        private ApplyCalculation<int> _receiveDamageApply;
        private ApplyAction _logSurvivorApply;
        #endregion

        #region Constructor
        public CharacterGroup(string groupName, 
            AggregationCalculation<bool, bool> deadCalc,
            AggregationCalculation<int, int> dealDamageCalc,
            ApplyCalculation<int> receiveDamageApply,
            ApplyAction logSurvivorApply)
        {
            _group = new List<Character>();
            _groupName = groupName;
            _deadCalc = deadCalc;
            _dealDamageCalc = dealDamageCalc;
            _receiveDamageApply = receiveDamageApply;
            _logSurvivorApply = logSurvivorApply;
        }
        #endregion

        #region Properties
        public string GroupName
        {
            get { return _groupName; }
        }

        public bool Dead
        {
            get
            {
                return _deadCalc.CalculateAggregate(_group);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add one Character to the group 
        /// </summary>
        public void AddCharacter(Character aBeast)
        {
            _group.Add(aBeast);
        }

        public int DealDamage()
        {
            return _dealDamageCalc.CalculateAggregate(_group);
        }

        public void ReceiveDamage(int damage)
        {
            _receiveDamageApply.Apply(_group, damage);
        }

        public void LogSurvivor()
        {
            _logSurvivorApply.Apply(_group);
        }
        #endregion
    }
}