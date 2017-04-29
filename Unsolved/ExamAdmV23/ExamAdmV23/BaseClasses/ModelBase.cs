using System.Collections.Generic;
using System.Linq;

namespace ExamAdmV23.BaseClasses
{
    /// <summary>
    /// This class can be used as a base class for a 
    /// collection of domain objects
    /// </summary>
    /// <typeparam name="TDomainClass">Type of domain object (e.g. Student)</typeparam>
    /// <typeparam name="TKey">Type of key for a domain object (e.g. string)</typeparam>
    public abstract class ModelBase<TDomainClass, TKey>
        where TDomainClass : DomainClassBase<TKey>
    {
        /// <summary>
        /// Uses a Dictionary to store domain objects,
        /// so they can be looked up using a key value
        /// </summary>
        private Dictionary<TKey, TDomainClass> _model;

        protected ModelBase()
        {
            _model = new Dictionary<TKey, TDomainClass>();
        }

        /// <summary>
        /// Returns all domain objects in a List
        /// </summary>
        public List<TDomainClass> All
        {
            get { return _model.Values.ToList(); }
        }

        /// <summary>
        /// Adds a single domain object to the collection
        /// </summary>
        /// <param name="key">Key for domain object</param>
        /// <param name="value">The domain object to add</param>
        public void Add(TDomainClass value)
        {
            _model.Add(value.Key, value);
        }

        /// <summary>
        /// Deletes a single domain object from the collection,
        /// given its key
        /// </summary>
        /// <param name="key">Key for domain object to delete</param>
        /// <returns></returns>
        public bool Delete(TKey key)
        {
            return _model.Remove(key);
        }
    }
}