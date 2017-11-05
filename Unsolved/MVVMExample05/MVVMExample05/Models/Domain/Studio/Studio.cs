using DataTransformation.Implementation;

namespace MVVMExample05.Models.Domain.Studio
{
    public class Studio : TransformedBase<Studio>
    {
        public Studio()
        {
        }

        public Studio(int key, string name, string hqCity, int noOfEmployees) 
            : base(key)
        {
            Name = name;
            HQCity = hqCity;
            NoOfEmployees = noOfEmployees;
        }

        public string Name { get; set; }
        public string HQCity { get; set; }
        public int NoOfEmployees { get; set; }

        public override void SetValuesFromObject(Studio obj)
        {
            Key = obj.Key;
            Name = obj.Name;
            HQCity = obj.HQCity;
            NoOfEmployees = obj.NoOfEmployees;
        }
    }
}