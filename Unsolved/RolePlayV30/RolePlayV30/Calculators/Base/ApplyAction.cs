using System.Collections.Generic;
using RolePlayV30.Characters;

namespace RolePlayV30.Calculators.Base
{
    public abstract class ApplyAction
    {
        public void Apply(List<Character> group)
        {
            foreach (Character c in @group)
            {
                if (IndividualCondition(c))
                {
                    ApplyToIndividual(c);
                }
            }
        }

        public virtual bool IndividualCondition(Character c)
        {
            return !c.Dead;
        }

        public abstract void ApplyToIndividual(Character c);
    }
}