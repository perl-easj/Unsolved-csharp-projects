using PvPSimulator.Player;

namespace PvPSimulator.PlayerFactory
{
    /// <summary>
    /// Example of a very specific implementation of the 
    /// IPlayerFactory interface. This implementation will
    /// always produce a Knight and a Warrior object.
    /// </summary>
    public class WarriorVsKnightFactory : IPlayerFactory
    {
        #region Constructor
        public WarriorVsKnightFactory()
        {
        }
        #endregion

        #region Methods
        public IPlayer CreatePlayerA()
        {
            return new Warrior("Asgard");
        }

        public IPlayer CreatePlayerB()
        {
            return new Knight("Sir Wallace");
        } 
        #endregion
    }
}