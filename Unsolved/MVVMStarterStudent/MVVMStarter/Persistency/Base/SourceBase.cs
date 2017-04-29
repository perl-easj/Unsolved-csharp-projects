using System.Threading.Tasks;
using MVVMStarter.Models.Base;

namespace MVVMStarter.Persistency.Base
{
    /// <summary>
    /// Specifies the methods that any source-handling class must implement.
    /// </summary>
    /// <typeparam name="TObjectClass"></typeparam>
    public abstract class SourceBase<TObjectClass>
        where TObjectClass : DomainClassBase
    {
        /// <summary>
        /// Loads domain objects from source
        /// </summary>
        /// <returns>
        /// Collection of domain objects (wrapped in Task object)
        /// </returns>
        public abstract Task<CollectionBase<TObjectClass>> Load();

        /// <summary>
        /// Saves domain objects to source
        /// </summary>
        /// <param name="collection">
        /// Collection of domain objects to save
        /// </param>
        public abstract void Save(CollectionBase<TObjectClass> collection);
    }
}
