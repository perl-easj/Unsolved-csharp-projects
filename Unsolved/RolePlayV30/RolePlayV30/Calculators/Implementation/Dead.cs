using RolePlayV30.Calculators.Base;
using RolePlayV30.Characters;

namespace RolePlayV30.Calculators.Implementation
{
    public class Dead : AggregationCalculation<bool, bool>
    {
        public override bool InitialValue()
        {
            return true;
        }

        public override bool IndividualCondition(Character c)
        {
            return true;
        }

        public override bool IndividualContribution(Character c)
        {
            return c.Dead;
        }

        public override bool AddContribution(bool aggregate, bool individualContribution)
        {
            return aggregate && individualContribution;
        }
    }
}