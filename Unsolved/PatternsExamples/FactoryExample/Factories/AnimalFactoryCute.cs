using FactoryExample.Animals;

namespace FactoryExample.Factories
{
    public class AnimalFactoryCute : IAnimalFactory
    {
        public IAnimal CreateAnimal(int age)
        {
            IAnimal aRabbit = new Rabbit("A white Rabbit");
            IAnimal aGoat = new Goat("A cute little Goat");
            IAnimal aPony = new Pony("Li'l Sebastian");

            if (age >= aPony.AgeMinimum) { return aPony; }
            else if (age >= aGoat.AgeMinimum) { return aGoat; }
            else if (age >= aRabbit.AgeMinimum) { return aRabbit; }
            else { return null; }
        }
    }
}