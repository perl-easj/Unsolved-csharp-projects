using FactoryExample.Foods;

namespace FactoryExample.Factories
{
    public class FoodFactoryCute : IFoodFactory
    {
        public IFood CreateFood(int money)
        {
            IFood aCucumber = new Cucumber();
            IFood aCarrot = new Carrot();
            IFood aCabbage = new Cabbage();

            if (money >= aCucumber.CostPerKg) { return aCucumber; }
            else if (money >= aCarrot.CostPerKg) { return aCarrot; }
            else if (money >= aCabbage.CostPerKg) { return aCabbage; }
            else { return null; }
        }
    }
}