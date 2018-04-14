using FactoryExample.Animals;
using FactoryExample.Helpers;

namespace FactoryExample.Zoos
{
    public class PettingZooV40
    {
        public PettingZooV40(Child aChild)
        {
            TheChild = aChild;
            IAnimal aRabbit = new Rabbit("A White Rabbit");
            IAnimal aGoat = new Goat("A cute little Goat");
            if (aChild.Age >= aGoat.AgeMinimum)
            {
                TheAnimal = aGoat;
            }
            else if (aChild.Age >= aRabbit.AgeMinimum)
            {
                TheAnimal = aRabbit;
            }
            else
            {
                //...?
            }
        }

        public Child TheChild { get; }
        public IAnimal TheAnimal { get; }

        public void Interact()
        {
            // Just pet the damn thing...
        }
    }
}