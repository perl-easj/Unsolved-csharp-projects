using System;
using DataTransformation.Implementation;

namespace MVVMExample05.DataTransformation.Domain.Studio
{
    public class StudioViewModelFactory : FactoryBase<Models.Domain.Studio.Studio, StudioViewModel>
    {
        public override Models.Domain.Studio.Studio CreateDomainObject(StudioViewModel vmObj)
        {
            return new Models.Domain.Studio.Studio(
                vmObj.Key,
                vmObj.Name,
                vmObj.HQCity,
                Int32.Parse(vmObj.NoOfEmployees));
        }
    }
}