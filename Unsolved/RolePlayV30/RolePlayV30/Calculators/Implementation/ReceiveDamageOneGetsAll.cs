using System.Collections.Generic;
using RolePlayV30.Calculators.Base;
using RolePlayV30.Characters;

namespace RolePlayV30.Calculators.Implementation
{
    public class ReceiveDamageOneGetsAll : ApplyCalculation<int>
    {
        public override void CalculateDivision(List<Character> group, List<int> division, int amount)
        {
            for (int i = 0; i < group.Count; i++)
            {
                if (!group[i].Dead)
                {
                    division[i] = amount;
                    return;
                }
            }
        }

        public override void ApplyToIndividual(Character c, int amount)
        {
            c.ReceiveDamage(amount);
        }
    }
}