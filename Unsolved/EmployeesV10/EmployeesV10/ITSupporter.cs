namespace EmployeesV10
{
    class ITSupporter : Employee
    {
        private string _primaryWorkArea;



        public string PrimaryWorkArea
        {
            get { return _primaryWorkArea; }
            set { _primaryWorkArea = value; }
        }

        public string AllInformation
        {
            get
            {
                string information = "IT-Supporter " + Name + " works " + HoursPerWeek + " hours/week, mostly with " + PrimaryWorkArea;
                return information;
            }
        }

        public ITSupporter(string name, int hoursPerWeek, string primaryWorkArea)
            : base(name, hoursPerWeek)
        {
            _primaryWorkArea = primaryWorkArea;
        }
    }
}
