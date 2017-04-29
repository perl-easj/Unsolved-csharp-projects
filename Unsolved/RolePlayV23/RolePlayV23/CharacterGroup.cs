using System.Collections.Generic;

namespace RolePlayV23
{
    class CharacterGroup
    {
        private List<Character> _group;
        private string _groupName;

        public string GroupName
        {
            get { return _groupName; }
        }

        public CharacterGroup(string groupName)
        {
            _group = new List<Character>();
            _groupName = groupName;
        }

        /// <summary>
        /// Add one Character to the group 
        /// </summary>
        public void AddCharacter(Character aBeast)
        {
            _group.Add(aBeast);
        }

        /// <summary>
        /// Dead is defined as: All members of the group must be dead
        /// </summary>
        public bool Dead
        {
            get
            {
                foreach (Character member in _group)
                {
                    if (!member.Dead)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// DealDamage is defined as: the total damage dealt by 
        /// all non-dead members of the group
        /// </summary>
        public int DealDamage()
        {
            int totalDamage = 0;

            foreach (Character member in _group)
            {
                if (!member.Dead)
                {
                    totalDamage = totalDamage + member.DealDamage();
                }
            }

            return totalDamage;
        }

        /// <summary>
        /// ReceiveDamage is defined as: the first non-dead 
        /// member in the list receives all of the damage
        /// </summary>
        public void ReceiveDamage(int damage)
        {
            foreach (Character member in _group)
            {
                if (!member.Dead)
                {
                    member.ReceiveDamage(damage);
                    return;
                }
            }
        }

        public void LogSurvivor()
        {
            foreach (Character member in _group)
            {
                if (!member.Dead)
                {
                    member.LogSurvivor();
                }
            }
        }
    }
}
