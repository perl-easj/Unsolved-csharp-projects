using FactoryExample.Animals;
using FactoryExample.Foods;

namespace FactoryExample.Factories
{
    public class PettingZooElementsFactoryCute 
        : IPettingZooElementsFactory
    {
        private FoodFactoryCute _ffCute;
        private AnimalFactoryCute _afCute;

        public PettingZooElementsFactoryCute()
        {
            _ffCute = new FoodFactoryCute();
            _afCute = new AnimalFactoryCute();
        }

        public IFood CreateFood(int money)
        {
            return _ffCute.CreateFood(money);
        }

        public IAnimal CreateAnimal(int age)
        {
            return _afCute.CreateAnimal(age);
        }
    }
}