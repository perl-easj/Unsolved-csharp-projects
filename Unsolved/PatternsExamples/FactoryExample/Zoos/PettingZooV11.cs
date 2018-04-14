using FactoryExample.Animals;
using FactoryExample.Helpers;

namespace FactoryExample.Zoos
{
    public class PettingZooV11
    {
        public PettingZooV11(Child aChild)
        {
            TheChild = aChild;
            TheRabbit = new Rabbit("A white Rabbit");
        }

        public Child TheChild { get; }
        public Rabbit TheRabbit { get; }

        public void Interact(Child c, Rabbit r)
        {
            // Just pet the damn thing...
        }
    }
}