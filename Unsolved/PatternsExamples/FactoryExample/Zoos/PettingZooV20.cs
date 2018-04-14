using FactoryExample.Animals;
using FactoryExample.Helpers;

namespace FactoryExample.Zoos
{
    public class PettingZooV20
    {
        public PettingZooV20(Child aChild, string animalType)
        {
            TheChild = aChild;
            if (animalType == "Rabbit")
            {
                TheAnimal = new Rabbit("A white Rabbit");
            }
            else
            {
                TheAnimal = new Goat("Cute little Goat");
            }
        }

        public Child TheChild { get; }
        public Animal TheAnimal { get; }

        public void Interact()
        {
            // Just pet the damn thing...
        }
    }
}