using FactoryExample.Animals;

namespace FactoryExample.Factories
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(int age);
    }
}