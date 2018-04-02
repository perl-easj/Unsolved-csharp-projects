namespace PvPSimulator.Player
{
    /// <inheritdoc />
    /// <summary>
    /// Derived player class, defining a Warrior player type.
    /// </summary>
    public class Warrior : Player
    {
        public Warrior(string name) : base(name, "Warrior", 150, 25)
        {
        }
    }
}