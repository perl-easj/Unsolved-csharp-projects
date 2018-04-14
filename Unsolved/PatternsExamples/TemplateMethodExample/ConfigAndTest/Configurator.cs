using TemplateMethodExample.Base;
using TemplateMethodExample.Derived;

namespace TemplateMethodExample.ConfigAndTest
{
    public class Configurator
    {
        public static Client Configure(bool fairOrBiased)
        {
            IFightClub fightClub = fairOrBiased ? (IFightClub) new FightClubFair() : new FightClubBiasedA();
            Client c = new Client(fightClub);

            return c;
        }
    }
}