namespace RolePlayV23
{
    class BattleHandler
    {
        public static void DoBattle(CharacterGroup groupA, CharacterGroup groupB)
        {
            while (!groupA.Dead && !groupB.Dead)
            {
                groupB.ReceiveDamage(groupA.DealDamage());

                if (!groupB.Dead)
                {
                    groupA.ReceiveDamage(groupB.DealDamage());
                }
            }

            BattleLog.Save("--------------- BATTLE IS OVER ------------");
            BattleLog.Save((groupA.Dead ? groupB.GroupName : groupA.GroupName) + " won! Status: ");
            groupA.LogSurvivor();
            groupB.LogSurvivor();

            BattleLog.PrintLog();
        }
    }
}
