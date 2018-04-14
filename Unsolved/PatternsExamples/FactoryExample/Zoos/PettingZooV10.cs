using FactoryExample.Animals;
using FactoryExample.Helpers;

namespace FactoryExample.Zoos
{
    public class PettingZooV10
    {
        public PettingZooV10()
        {
            TheChild = new Child("Jan", 6);
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