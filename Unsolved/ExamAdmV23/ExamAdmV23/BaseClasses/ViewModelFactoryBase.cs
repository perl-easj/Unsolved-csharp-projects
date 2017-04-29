namespace ExamAdmV23.BaseClasses
{
    /// <summary>
    /// A domain-specific factory class must inherit from
    /// this class, and implement its methods
    /// </summary>
    /// <typeparam name="TDomainClass">Type of domain object (e.g. Student)</typeparam>
    /// <typeparam name="TKey">Type of key for a domain object (e.g. string)</typeparam>
    public abstract class ViewModelFactoryBase<TDomainClass, TKey>
        where TDomainClass : DomainClassBase<TKey>
    {
        public abstract ItemViewModelBase<TDomainClass> CreateItemViewModel(TDomainClass obj);
        public abstract MasterViewModelBase<TDomainClass, TKey> CreateMasterViewModel();
    }
}