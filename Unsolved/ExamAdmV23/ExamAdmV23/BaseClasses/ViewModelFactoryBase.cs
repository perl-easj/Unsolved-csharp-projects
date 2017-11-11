using System.Collections.Generic;

namespace ExamAdmV23.BaseClasses
{
    /// <summary>
    /// A domain-specific factory class must inherit from
    /// this class, and implement its methods
    /// </summary>
    /// <typeparam name="TDomainClass">Type of domain object (e.g. Student)</typeparam>
    public abstract class ViewModelFactoryBase<TDomainClass>
        where TDomainClass : DomainClassBase
    {
        public abstract ItemViewModelBase<TDomainClass> CreateItemViewModel(TDomainClass obj);

        public List<ItemViewModelBase<TDomainClass>> GetItemViewModelCollection(CatalogBase<TDomainClass> catalog)
        {
            List<ItemViewModelBase<TDomainClass>> items = new List<ItemViewModelBase<TDomainClass>>();

            foreach (TDomainClass obj in catalog.All)
            {
                items.Add(CreateItemViewModel(obj));
            }

            return items;
        }
    }
}