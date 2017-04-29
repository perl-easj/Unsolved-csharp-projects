using MVVMStarter.ViewModels.Base;
using _REPLACEME_Class = MVVMStarter.Models.Domain._REPLACEME_._REPLACEME_;

/// <summary>
/// TEMPLATE: You must 
/// 1) Create a file called ViewModelFactory.cs in your domain folder (under ViewModel/Domain)
/// 2) Delete the entire content of the file
/// 3) Copy-paste the entire content of this template into the file
/// 4) replace the text _REPLACEME_ with the name of your domain
/// 5) Delete this comment
/// </summary>
namespace MVVMStarter.ViewModels.Domain._REPLACEME_
{
    public class ViewModelFactory : ViewModelFactoryBase<_REPLACEME_Class>
    {
        public override DetailsViewModelBase<_REPLACEME_Class> CreateDetailsViewModel(_REPLACEME_Class obj)
        {
            return new DetailsViewModel(obj);
        }

        public override ItemViewModelBase<_REPLACEME_Class> CreateItemViewModel(_REPLACEME_Class obj)
        {
            return new ItemViewModel(obj);
        }

        public override MasterViewModelBase<_REPLACEME_Class> CreateMasterViewModel()
        {
            return new MasterViewModel();
        }
    }
}
