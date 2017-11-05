using DataTransformation.Interfaces;
using MVVMExample05.DataTransformation.Domain.Studio;
using ViewModel.Implementation;

namespace MVVMExample05.ViewModels.Domain.Studio
{
    public class ViewModelFactory : ViewModelFactoryBase<Models.Domain.Studio.Studio, StudioViewModel>
    {
        public override IDataWrapper<StudioViewModel> CreateDetailsViewModel(StudioViewModel obj)
        {
            return new DetailsViewModel(obj);
        }

        public override IDataWrapper<StudioViewModel> CreateItemViewModel(StudioViewModel obj)
        {
            return new ItemViewModel(obj);
        }
    }
}