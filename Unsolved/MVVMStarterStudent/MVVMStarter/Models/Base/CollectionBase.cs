using System.Collections.Generic;
using System.Linq;

namespace MVVMStarter.Models.Base
{
    /// <summary>
    /// Contains collection-oriented functionality for domain objects.
    /// </summary>
    /// <typeparam name="TDomainClass">
    /// Type for specific domain objects
    /// </typeparam>
    public class CollectionBase<TDomainClass> where TDomainClass : DomainClassBase
    {
        private Dictionary<int, TDomainClass> _collection;

        public CollectionBase()
        {
            _collection = new Dictionary<int, TDomainClass>();
        }

        /// <summary>
        /// Returns all values stored in the collection as a List object
        /// </summary>
        public List<TDomainClass> All
        {
            get { return _collection.Values.ToList(); }
        }

        /// <summary>
        /// Inserts a single domain object into the collection
        /// </summary>
        /// <param name="obj">
        /// Domain object to insert.
        /// </param>
        /// <param name="replaceKey">
        /// Specifies if the Key value should be overwritten.
        /// </param>
        public void Insert(TDomainClass obj, bool replaceKey = true)
        {
            if (replaceKey)
            {
                obj.Key = NextKey();
            }
            _collection.Add(obj.Key, obj);
        }

        /// <summary>
        /// Deletes a single domain object from the collection
        /// </summary>
        /// <param name="key">
        /// Key for object to delete from collection
        /// </param>
        /// <returns>
        /// Return true if an object was actually deleted.
        /// </returns>
        public bool Delete(int key)
        {
            return _collection.Remove(key);
        }

        /// <summary>
        /// Deletes all domain objects from the collection unconditionally.
        /// </summary>
        public void DeleteAll()
        {
            _collection.Clear();
        }

        /// <summary>
        /// Retrieves the object corresponding to the given key
        /// </summary>
        /// <param name="key">Key of object to retrieve</param>
        /// <returns>The domain object corresponding to the given key</returns>
        public TDomainClass Read(int key)
        {
            return _collection.ContainsKey(key) ? _collection[key] : null;
        }

        /// <summary>
        /// Finds the next valid key for a new object to be inserted
        /// into the collection.
        /// </summary>
        /// <returns>
        /// Key to assign to new object.
        /// </returns>
        private int NextKey()
        {
            return ((_collection.Count == 0) ? 0 : _collection.Keys.Max() + 1);
        }
    }
}
