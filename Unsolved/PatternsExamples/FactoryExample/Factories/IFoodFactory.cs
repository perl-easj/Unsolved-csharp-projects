using FactoryExample.Foods;

namespace FactoryExample.Factories
{
    public interface IFoodFactory
    {
        IFood CreateFood(int money);
    }
}