using System.Collections.Generic;
using RolePlayV30.Characters;

namespace RolePlayV30.Calculators.Base
{
    public abstract class ApplyCalculation<T>
    {
        public void Apply(List<Character> group, T amount, T defaultIndividualAmount = default(T))
        {
            List<T> amountDivision = new List<T>();
            for (int i = 0; i < group.Count; i++)
            {
                amountDivision.Add(defaultIndividualAmount);
            }

            CalculateDivision(group, amountDivision, amount);
            for (int i = 0; i < group.Count; i++)
            {
                if (IndividualCondition(group[i]))
                {
                    ApplyToIndividual(group[i], amountDivision[i]);
                }
            }

        }

        public virtual bool IndividualCondition(Character c)
        {
            return !c.Dead;
        }

        public abstract void CalculateDivision(List<Character> group, List<T> division, T amount);
        public abstract void ApplyToIndividual(Character c, T amount);
    }
}