namespace WeaponShopV10
{
    /// <summary>
    /// This class represents a Axe. An Axe is 
    /// considered to be a weapon.
    /// </summary>
    public class Axe : Weapon
    {
        public const int AxeMinDamage = 20;
        public const int AxeMaxDamage = 50;

        #region Constructor
        public Axe(string description) : base(description, AxeMinDamage, AxeMaxDamage)
        {
        } 
        #endregion
    }
}