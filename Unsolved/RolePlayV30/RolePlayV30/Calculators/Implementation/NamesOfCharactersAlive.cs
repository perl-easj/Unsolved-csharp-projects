using System.Collections.Generic;
using RolePlayV30.Calculators.Base;
using RolePlayV30.Characters;

namespace RolePlayV30.Calculators.Implementation
{
    public class NamesOfCharactersAlive : AggregationCalculation<List<string>, string>
    {
        public override List<string> InitialValue()
        {
            return new List<string>();
        }

        public override string IndividualContribution(Character c)
        {
            return c.Name;
        }

        public override List<string> AddContribution(List<string> aggregate, string individualContribution)
        {
            aggregate.Add(individualContribution);
            return aggregate;
        }
    }
}