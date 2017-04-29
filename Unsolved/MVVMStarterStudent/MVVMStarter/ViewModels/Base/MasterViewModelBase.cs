using System.Collections.ObjectModel;
using MVVMStarter.Models.Base;

namespace MVVMStarter.ViewModels.Base
{
    public abstract class MasterViewModelBase<TDomainClass> 
        where TDomainClass : DomainClassBase
    {
        private ObservableCollection<ItemViewModelBase<TDomainClass>> _itemViewModelCollection;

        public virtual ObservableCollection<ItemViewModelBase<TDomainClass>> CreateItemViewModelCollection(
            DomainModelBase<TDomainClass> domainModel, 
            ViewModelFactoryBase<TDomainClass> factory)
        {
            _itemViewModelCollection.Clear();

            foreach (TDomainClass obj in domainModel.All)
            {
                _itemViewModelCollection.Add(factory.CreateItemViewModel(obj));
            }

            return _itemViewModelCollection;
        }

        public MasterViewModelBase()
        {
            _itemViewModelCollection = new ObservableCollection<ItemViewModelBase<TDomainClass>>();
        }
    }
}
