using FactoryExample.Animals;
using FactoryExample.Foods;

namespace FactoryExample.Factories
{
    public interface IPettingZooElementsFactory
    {
        IFood CreateFood(int money);
        IAnimal CreateAnimal(int age);
    }
}