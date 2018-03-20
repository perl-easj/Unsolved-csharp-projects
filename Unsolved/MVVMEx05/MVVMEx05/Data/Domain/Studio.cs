using MVVMEx05.Data.Base;

namespace MVVMEx05.Data.Domain
{
    public class Studio : DomainClassAppBase
    {
        #region Constructors
        public Studio() : base(NullKey)
        {
        }

        public Studio(int imageKey, string name, string hqCity, int noOfEmployees)
            : base(imageKey)
        {
            Name = name;
            HQCity = hqCity;
            NoOfEmployees = noOfEmployees;
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public string HQCity { get; set; }
        public int NoOfEmployees { get; set; }
        #endregion

        #region Methods
        public override void SetDefaultValues()
        {
            Name = NotSet;
            HQCity = NotSet;
            NoOfEmployees = 120;
        } 
        #endregion
    }
}