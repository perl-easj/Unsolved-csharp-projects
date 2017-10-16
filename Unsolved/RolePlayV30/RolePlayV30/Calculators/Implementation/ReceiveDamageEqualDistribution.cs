using System.Collections.Generic;
using RolePlayV30.Calculators.Base;
using RolePlayV30.Characters;

namespace RolePlayV30.Calculators.Implementation
{
    public class ReceiveDamageEqualDistribution : ApplyCalculation<int>
    {
        public override void CalculateDivision(List<Character> group, List<int> division, int amount)
        {
            int individualAmount = LivingCount(group) == 0 ? 0 : amount / LivingCount(group);
            for (int i = 0; i < group.Count; i++)
            {
                if (!group[i].Dead)
                {
                    division[i] = individualAmount;
                }
            }
        }

        public override void ApplyToIndividual(Character c, int amount)
        {
            c.ReceiveDamage(amount);
        }

        private int LivingCount(List<Character> group)
        {
            int livingCount = 0;
            foreach (Character c in group)
            {
                if (!c.Dead)
                {
                    livingCount++;
                }
            }

            return livingCount;
        }
    }
}