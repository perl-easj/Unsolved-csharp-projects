using FactoryExample.Animals;
using FactoryExample.Helpers;

namespace FactoryExample.Zoos
{
    public class PettingZooV31
    {
        public PettingZooV31(Child aChild, IAnimal anAnimal)
        {
            TheChild = aChild;
            TheAnimal = anAnimal;
        }

        public Child TheChild { get; }
        public IAnimal TheAnimal { get; }

        public void Interact(Child c, IAnimal a)
        {
            // Just pet the damn thing...
        }
    }
}