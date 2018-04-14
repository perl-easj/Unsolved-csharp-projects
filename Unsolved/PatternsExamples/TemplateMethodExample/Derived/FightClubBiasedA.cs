using System;
using TemplateMethodExample.Base;

namespace TemplateMethodExample.Derived
{
    public class FightClubBiasedA : FightClubBase
    {
        protected override void ExchangeBlows(Fighter fa, Fighter fb)
        {
            Fighter first = fa;
            Fighter last = fb;

            last.ReceiveDamage(first.DealDamage());
            if (!last.Stop)
            {
                first.ReceiveDamage(last.DealDamage());
            }
        }

        protected override void Report(int winsA, int winsB)
        {
            Console.WriteLine($"Biased Fight Club results: ");
            base.Report(winsA, winsB);
        }
    }
}