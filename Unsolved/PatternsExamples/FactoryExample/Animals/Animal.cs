namespace FactoryExample.Animals
{
    public class Animal : IAnimal
    {
        public Animal(string description, int ageMinimum)
        {
            Description = description;
            AgeMinimum = ageMinimum;
        }

        public string Description { get; }
        public int AgeMinimum { get; }
    }
}