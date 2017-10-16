using System.Collections.Generic;
using RolePlayV30.Characters;

namespace RolePlayV30.Calculators.Base
{
    public abstract class AggregationCalculation<TA, TI>
    {
        public TA CalculateAggregate(List<Character> characters)
        {
            TA groupContribution = InitialValue();

            for (int i = 0; i < characters.Count && GroupCondition(characters); i++)
            {
                if (IndividualCondition(characters[i]))
                {
                    groupContribution = AddContribution(groupContribution, IndividualContribution(characters[i]));
                }
            }

            return groupContribution;
        }

        public virtual bool IndividualCondition(Character c)
        {
            return !c.Dead;
        }

        public virtual bool GroupCondition(List<Character> group)
        {
            return true;
        }

        public virtual TA InitialValue()
        {
            return default(TA);
        }

        public abstract TI IndividualContribution(Character c);
        public abstract TA AddContribution(TA aggregate, TI individualContribution);
    }
}