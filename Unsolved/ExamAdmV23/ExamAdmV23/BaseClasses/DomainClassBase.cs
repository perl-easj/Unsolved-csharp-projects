namespace ExamAdmV23.BaseClasses
{
    /// <summary>
    /// A domain class must inherit from this class,
    /// and implement the Key property
    /// </summary>
    /// <typeparam name="TKey">Type of key for a domain object</typeparam>
    public abstract class DomainClassBase<TKey>
    {
        public abstract TKey Key { get; }
    }
}
