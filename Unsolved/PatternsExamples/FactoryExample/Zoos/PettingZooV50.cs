using FactoryExample.Animals;
using FactoryExample.Helpers;

namespace FactoryExample.Zoos
{
    public class PettingZooV50
    {
        public PettingZooV50(Child aChild)
        {
            TheChild = aChild;
            TheAnimal = CreateAnimal(aChild.Age);
        }

        private IAnimal CreateAnimal(int age)
        {
            IAnimal aRabbit = new Rabbit("A White Rabbit");
            IAnimal aGoat = new Goat("A cute little Goat");
            if (age >= aGoat.AgeMinimum)
            {
                return aGoat;
            }
            else if (age >= aRabbit.AgeMinimum)
            {
                return aRabbit;
            }
            else
            {
                return null;
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