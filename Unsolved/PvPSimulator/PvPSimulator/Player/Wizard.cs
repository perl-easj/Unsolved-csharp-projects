namespace PvPSimulator.Player
{
    /// <inheritdoc />
    /// <summary>
    /// Derived player class, defining a Wizard player type.
    /// </summary>
    public class Wizard : Player
    {
        public Wizard(string name) : base(name, "Wizard", 90, 40)
        {
        }
    }
}