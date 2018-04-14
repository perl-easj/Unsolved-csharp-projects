using System;

namespace TemplateMethodExample.Base
{
    public abstract class FightClubBase : IFightClub
    {
        private const int NoOfFights = 100000;

        public void Fight(Fighter fa, Fighter fb)
        {
            int winsA = 0;
            int winsB = 0;

            for (int i = 0; i < NoOfFights; i++)
            {
                SingleFight(fa, fb);
                winsA += fa.Stop ? 0 : 1;
                winsB += fb.Stop ? 0 : 1;
            }

            Report(winsA, winsB);
        }

        private void SingleFight(Fighter fighterA, Fighter fighterB)
        {
            // Reset both Fighters to original state
            fighterA.Reset();
            fighterB.Reset();

            // Fight until the death!
            while (!fighterA.Stop && !fighterB.Stop)
            {
                ExchangeBlows(fighterA, fighterB);
            }
        }

        protected virtual void Report(int winsA, int winsB)
        {
            double percentA = winsA * 100.0 / NoOfFights;
            double percentB = winsB * 100.0 / NoOfFights;

            Console.WriteLine($"Result of simulation:");
            Console.WriteLine($"Player A won {percentA:F2} % of fights.");
            Console.WriteLine($"Player B won {percentB:F2} % of fights.");
            Console.WriteLine();
        }

        protected abstract void ExchangeBlows(Fighter a, Fighter b);
    }
}