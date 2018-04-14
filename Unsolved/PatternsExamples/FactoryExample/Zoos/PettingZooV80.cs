using FactoryExample.Animals;
using FactoryExample.Factories;
using FactoryExample.Foods;
using FactoryExample.Helpers;

namespace FactoryExample.Zoos
{
    public class PettingZooV80
    {
        public PettingZooV80(Child aChild, IPettingZooElementsFactory factory)
        {
            TheChild = aChild;
            TheAnimal = factory.CreateAnimal(aChild.Age);
            TheFood = factory.CreateFood(aChild.MoneyLimit);
        }

        public Child TheChild { get; }
        public IAnimal TheAnimal { get; }
        public IFood TheFood { get; }

        public void Interact()
        {
            // Just pet and feed the damn thing...
        }
    }
}