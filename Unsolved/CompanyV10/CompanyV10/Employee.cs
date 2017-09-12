namespace CompanyV10
{
    /// <summary>
    /// This class is intended to act as a base class, 
    /// for other classes specific for certain kinds of employees
    /// </summary>
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

        #region Abstract methods
        public abstract int SalaryPerMonth { get; }

        public abstract int BonusPerMonth { get; }

        public abstract bool PayoutBonus { get; } 
        #endregion
    }
}
