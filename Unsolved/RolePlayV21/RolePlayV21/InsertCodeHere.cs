using System.Collections.Generic;

namespace RolePlayV21
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            NumberGenerator theNumberGenerator = new NumberGenerator();
            BattleLog theLog = new BattleLog();

            // Original battle logic (1-on-1)
            #region 1-on-1 battle logic
            Hero theHero = new Hero(theNumberGenerator, theLog, 100, 10, 30);
            Beast theBeast = new Beast(theNumberGenerator, theLog, 90, 10, 25);

            while (!theHero.Dead && !theBeast.Dead)
            {
                int damageByHero = theHero.DealDamage();
                theBeast.ReceiveDamage(damageByHero);

                if (!theBeast.Dead)
                {
                    int damageByBeast = theBeast.DealDamage();
                    theHero.ReceiveDamage(damageByBeast);
                }
            }

            theLog.PrintLog();
            #endregion


            // New battle logic (1-on-many)
            #region 1-on-many battle logic
            theHero.Reset();
            theLog.Reset();

            BeastArmy theArmy = new BeastArmy();
            Beast theBeast1 = new Beast(theNumberGenerator, theLog, 40, 10, 25);
            Beast theBeast2 = new Beast(theNumberGenerator, theLog, 20, 5, 15);
            Beast theBeast3 = new Beast(theNumberGenerator, theLog, 30, 8, 12);

            theArmy.AddBeast(theBeast1);
            theArmy.AddBeast(theBeast2);
            theArmy.AddBeast(theBeast3);

            while (!theHero.Dead && !theArmy.Dead)
            {
                int damageByHero = theHero.DealDamage();
                theArmy.ReceiveDamage(damageByHero);

                if (!theArmy.Dead)
                {
                    int damageByArmy = theArmy.DealDamage();
                    theHero.ReceiveDamage(damageByArmy);
                }
            }

            theLog.PrintLog(); 
            #endregion

            // The LAST line of code should be ABOVE this line
        }
    }
}