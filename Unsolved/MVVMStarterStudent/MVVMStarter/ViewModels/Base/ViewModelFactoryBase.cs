using MVVMStarter.Models.Base;

namespace MVVMStarter.ViewModels.Base
{
    public abstract class ViewModelFactoryBase<TDomainClass>
        where TDomainClass : DomainClassBase
    {
        public abstract DetailsViewModelBase<TDomainClass> CreateDetailsViewModel(TDomainClass obj);
        public abstract ItemViewModelBase<TDomainClass> CreateItemViewModel(TDomainClass obj);
        public abstract MasterViewModelBase<TDomainClass> CreateMasterViewModel();
    }
}
