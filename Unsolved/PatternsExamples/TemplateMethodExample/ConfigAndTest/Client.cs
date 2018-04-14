using TemplateMethodExample.Base;

namespace TemplateMethodExample.ConfigAndTest
{
    public class Client
    {
        private IFightClub _club;

        public Client(IFightClub club)
        {
            _club = club;
        }

        public void Run()
        {
            Fighter fA = new Fighter("Ragnar", 200, 25);
            Fighter fB = new Fighter("Rollo", 250, 20);
            _club.Fight(fA, fB);
        }
    }
}