namespace PvPSimulator.Tactics
{
    /// <summary>
    /// Class derived from TacticsInfo.
    /// Specifies a neutral strategy.
    /// </summary>
    public class NeutralTactics : TacticsInfo
    {
        public NeutralTactics() : base(TacticsType.Neutral, 1.0, 1.0)
        {
        }
    }
}
