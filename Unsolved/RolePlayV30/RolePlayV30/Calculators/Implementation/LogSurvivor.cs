using RolePlayV30.Calculators.Base;
using RolePlayV30.Characters;

namespace RolePlayV30.Calculators.Implementation
{
    public class LogSurvivor : ApplyAction
    {
        public override void ApplyToIndividual(Character c)
        {
            c.LogSurvivor();
        }
    }
}