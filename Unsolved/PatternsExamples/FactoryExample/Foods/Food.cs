namespace FactoryExample.Foods
{
    public class Food : IFood
    {
        public Food(string description, int costPerKg)
        {
            Description = description;
            CostPerKg = costPerKg;
        }

        public string Description { get; }
        public int CostPerKg { get; }
    }
}