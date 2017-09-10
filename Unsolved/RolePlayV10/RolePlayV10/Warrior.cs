namespace RolePlayV10
{
    public class Warrior
    {
        // Instance field
        private string _name;

        // Constructor
        public Warrior(string name)
        {
            _name = name;
        }

        // Property
        public string Name
        {
            get { return _name; }
        }
    }
}