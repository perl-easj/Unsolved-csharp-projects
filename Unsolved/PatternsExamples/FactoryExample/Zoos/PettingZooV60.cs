using FactoryExample.Animals;
using FactoryExample.Factories;
using FactoryExample.Helpers;

namespace FactoryExample.Zoos
{
    public class PettingZooV60
    {
        public PettingZooV60(Child aChild, IAnimalFactory aFactory)
        {
            TheChild = aChild;
            TheAnimal = aFactory.CreateAnimal(aChild.Age);
        }

        public Child TheChild { get; }
        public IAnimal TheAnimal { get; }

        public void Interact()
        {
            // Just pet the damn thing...
        }
    }
}