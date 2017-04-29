namespace RolePlayV23
{
    class Damager : Character
    {
        public Damager(string name, int hitPoints, int minDamage, int maxDamage) : base(name, hitPoints, minDamage, maxDamage)
        {
        }

        public override int DealDamage()
        {
            return 1;
        }
    }
}
