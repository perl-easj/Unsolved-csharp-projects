namespace PvPSimulator.Tactics
{
    /// <summary>
    /// Class derived from TacticsInfo.
    /// Specifies a defensive strategy.
    /// </summary>
    public class DefensiveTactics : TacticsInfo
    {
        public DefensiveTactics() : base(TacticsType.Defensive, 0.8, 1.3)
        {
        }
    }
}