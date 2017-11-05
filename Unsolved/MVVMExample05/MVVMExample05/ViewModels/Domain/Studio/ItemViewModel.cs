using DataTransformation.Implementation;
using MVVMExample05.DataTransformation.Domain.Studio;

namespace MVVMExample05.ViewModels.Domain.Studio
{
    public class ItemViewModel : DataWrapper<StudioViewModel>
    {
        public ItemViewModel(StudioViewModel obj) : base(obj)
        {
        }

        public string Description
        {
            get { return DataObject.Name; }
        }
    }
}