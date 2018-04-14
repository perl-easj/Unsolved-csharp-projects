using FactoryExample.Animals;
using FactoryExample.Helpers;

namespace FactoryExample.Zoos
{
    public class PettingZooV12
    {
        public PettingZooV12(Child aChild, Rabbit aRabbit)
        {
            TheChild = aChild;
            TheRabbit = aRabbit;
        }

        public Child TheChild { get; }
        public Rabbit TheRabbit { get; }

        public void Interact(Child c, Rabbit r)
        {
            // Just pet the damn thing...
        }
    }
}