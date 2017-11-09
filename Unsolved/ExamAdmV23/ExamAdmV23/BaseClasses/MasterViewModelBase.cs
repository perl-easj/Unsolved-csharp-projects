using System.Collections.Generic;

namespace ExamAdmV23.BaseClasses
{
    /// <summary>
    /// A domain-specific Master view model class must inherit
    /// from this class. No further implementation is needed.
    /// </summary>
    /// <typeparam name="TDomainClass"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class MasterViewModelBase<TDomainClass, TKey>
        where TDomainClass : DomainClassBase<TKey>
    {
        public List<ItemViewModelBase<TDomainClass>> GetItemViewModelCollection(
            CatalogBase<TDomainClass, TKey> collection,
            ViewModelFactoryBase<TDomainClass, TKey> factory)
        {
            List<ItemViewModelBase<TDomainClass>> items = new List<ItemViewModelBase<TDomainClass>>();

            foreach (TDomainClass obj in collection.All)
            {
                items.Add(factory.CreateItemViewModel(obj));
            }

            return items;
        }
    }
}
