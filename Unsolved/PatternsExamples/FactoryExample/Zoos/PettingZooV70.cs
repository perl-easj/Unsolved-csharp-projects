using FactoryExample.Animals;
using FactoryExample.Factories;
using FactoryExample.Foods;
using FactoryExample.Helpers;

namespace FactoryExample.Zoos
{
    public class PettingZooV70
    {
        public PettingZooV70(
            Child aChild,
            IAnimalFactory factoryAnimal,
            IFoodFactory factoryFood)
        {
            TheChild = aChild;
            TheAnimal = factoryAnimal.CreateAnimal(aChild.Age);
            TheFood = factoryFood.CreateFood(aChild.MoneyLimit);
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