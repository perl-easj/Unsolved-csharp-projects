using DataTransformation.Implementation;

namespace MVVMExample05.DataTransformation.Domain.Studio
{
    public class StudioViewModel : TransformedWithDefaultBase<Models.Domain.Studio.Studio>
    {
        public string Name { get; set; }
        public string HQCity { get; set; }
        public string NoOfEmployees { get; set; }

        public override void SetValuesFromObject(Models.Domain.Studio.Studio obj)
        {
            Name = obj.Name;
            HQCity = obj.HQCity;
            NoOfEmployees = obj.NoOfEmployees.ToString();
        }

        public override void SetDefaultValues()
        {
            Name = "(name)";
            HQCity = "(HQ city)";
            NoOfEmployees = "(no. of employees)";
        }
    }
}