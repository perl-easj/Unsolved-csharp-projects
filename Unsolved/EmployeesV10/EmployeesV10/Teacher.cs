namespace EmployeesV10
{
    class Teacher : Employee
    {
        private int _payGrade;

        public int PayGrade
        {
            get { return _payGrade; }
            set { _payGrade = value;}
        }

        public string AllInformation
        {
            get
            {
                string information = "Teacher " + Name + " works " + HoursPerWeek + " hours/week, at paygrade " + PayGrade;
                return information;
            }
        }

        public Teacher(string name, int hoursPerWeek, int payGrade)
            : base(name, hoursPerWeek)
        {
            _payGrade = payGrade;
        }
    }
}
