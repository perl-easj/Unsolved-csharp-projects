using System.Collections.Generic;
using System.Linq;

namespace ExamAdmV23.BaseClasses
{
    /// <summary>
    /// This class can be used as a base class for a 
    /// catalog class for domain objects
    /// </summary>
    /// <typeparam name="TDomainClass">Type of domain object (e.g. Student)</typeparam>
    /// <typeparam name="TKey">Type of key for a domain object (e.g. string)</typeparam>
    public abstract class CatalogBase<TDomainClass, TKey>
        where TDomainClass : DomainClassBase<TKey>
    {
        /// <summary>
        /// Uses a Dictionary to store domain objects,
        /// so they can be looked up using a key value
        /// </summary>
        private Dictionary<TKey, TDomainClass> _items;

        #region Constructor
        protected CatalogBase()
        {
            _items = new Dictionary<TKey, TDomainClass>();
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Returns all domain objects in a List
        /// </summary>
        public List<TDomainClass> All
        {
            get { return _items.Values.ToList(); }
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Adds a single domain object to the collection
        /// </summary>
        /// <param name="value">The domain object to add</param>
        public void Add(TDomainClass value)
        {
            _items.Add(value.Key, value);
        }

        /// <summary>
        /// Deletes a single domain object from the catalog,
        /// given its key
        /// </summary>
        /// <param name="key">Key for domain object to delete</param>
        /// <returns></returns>
        public bool Delete(TKey key)
        {
            return _items.Remove(key);
        } 
        #endregion
    }
}