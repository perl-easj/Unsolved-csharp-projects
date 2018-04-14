using FactoryExample.Animals;
using FactoryExample.Helpers;

namespace FactoryExample.Zoos
{
    public class PettingZooV30
    {
        public PettingZooV30(Child aChild, Animal anAnimal)
        {
            TheChild = aChild;
            TheAnimal = anAnimal;
        }

        public Child TheChild { get; }
        public Animal TheAnimal { get; }

        public void Interact(Child c, Animal a)
        {
            // Just pet the damn thing...
        }
    }
}