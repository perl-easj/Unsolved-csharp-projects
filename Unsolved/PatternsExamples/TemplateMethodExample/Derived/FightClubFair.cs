using System;
using TemplateMethodExample.Base;

namespace TemplateMethodExample.Derived
{
    public class FightClubFair : FightClubBase
    {
        private static Random _generator = new Random(Guid.NewGuid().GetHashCode());

        protected override void ExchangeBlows(Fighter fa, Fighter fb)
        {
            int percent = GeneratePercent();
            Fighter first = percent >= 50 ? fa : fb;
            Fighter last = percent >= 50 ? fb : fa;

            last.ReceiveDamage(first.DealDamage());
            if (!last.Stop)
            {
                first.ReceiveDamage(last.DealDamage());
            }
        }

        protected override void Report(int winsA, int winsB)
        {
            Console.WriteLine($"Fair Fight Club results: ");
            base.Report(winsA, winsB);
        }

        private int GeneratePercent()
        {
            return _generator.Next(0, 100);
        }
    }
}