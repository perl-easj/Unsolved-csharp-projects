namespace PvPSimulator.Tactics
{
    /// <summary>
    /// Class derived from TacticsInfo.
    /// Specifies an offensive strategy.
    /// </summary>
    public class OffensiveTactics : TacticsInfo
    {
        public OffensiveTactics() : base(TacticsType.Offensive, 1.2, 0.85)
        {
        }
    }
}