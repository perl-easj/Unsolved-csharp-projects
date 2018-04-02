namespace PvPSimulator.Player
{
    /// <inheritdoc />
    /// <summary>
    /// Derived player class, defining a Knight player type.
    /// </summary>
    public class Knight : Player
    {
        public Knight(string name) : base(name, "Knight", 120, 30)
        {
        }
    }
}