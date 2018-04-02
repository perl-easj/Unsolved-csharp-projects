using PvPSimulator.Player;

namespace PvPSimulator.PlayerFactory
{
    /// <summary>
    /// Default implementation of the IPlayerFactory interface.
    /// A user of the class will provide two already created
    /// IPlayer objects to the factory. The factory is thus
    /// incapable of producing truly new objects, and is thus
    /// a kind of pseudo-factory.
    /// </summary>
    public class DefaultPlayerFactory : IPlayerFactory
    {
        #region Instance fields
        private IPlayer _playerA;
        private IPlayer _playerB;
        #endregion

        #region Constructor
        public DefaultPlayerFactory(IPlayer playerA, IPlayer playerB)
        {
            _playerA = playerA;
            _playerB = playerB;
        }
        #endregion

        #region Methods
        public IPlayer CreatePlayerA()
        {
            return _playerA;
        }

        public IPlayer CreatePlayerB()
        {
            return _playerB;
        } 
        #endregion
    }
}