namespace FactoryExample.Helpers
{
    public class Child
    {
        public Child(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }
        public int MoneyLimit { get { return Age * 3; } }
    }
}