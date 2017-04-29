namespace CompanyV10
{
    public abstract class Employee
    {
        private string _name;

        protected Employee(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public abstract int SalaryPerMonth { get; }

        public abstract int BonusPerMonth { get; }

        public abstract bool PayoutBonus { get; }
    }
}
