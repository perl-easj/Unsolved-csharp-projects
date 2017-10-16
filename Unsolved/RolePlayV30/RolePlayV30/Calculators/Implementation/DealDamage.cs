using RolePlayV30.Calculators.Base;
using RolePlayV30.Characters;

namespace RolePlayV30.Calculators.Implementation
{
    public class DealDamage : AggregationCalculation<int, int>
    {
        public override int InitialValue()
        {
            return 0;
        }

        public override int IndividualContribution(Character c)
        {
            return c.DealDamage();
        }

        public override int AddContribution(int aggregate, int individualContribution)
        {
            return aggregate + individualContribution;
        }
    }
}