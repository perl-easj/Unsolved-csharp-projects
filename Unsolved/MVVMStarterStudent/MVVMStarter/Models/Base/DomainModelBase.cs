using System;
using System.Collections.Generic;
using MVVMStarter.Persistency.Base;

namespace MVVMStarter.Models.Base
{
    /// <summary>
    /// Base class for a domain model. A domain model is defined as a
    /// collection of domain objects, plus a source for retrieving the
    /// domain objects.
    /// </summary>
    /// <typeparam name="TDomainClass">
    /// Type of specific domain object for which this is a model
    /// </typeparam>
    public class DomainModelBase<TDomainClass> where TDomainClass : DomainClassBase
    {
        private CollectionBase<TDomainClass> _collection;
        private SourceBase<TDomainClass> _source;
        private bool _modified;

        /// <summary>
        /// Sets up the model as a paired collection and source
        /// </summary>
        /// <param name="collection">
        /// In-memory collection of domain objects
        /// </param>
        /// <param name="source"></param>
        /// Source for loading/saving domain objects
        /// <param name="loadWhenCreated"></param>
        public DomainModelBase(CollectionBase<TDomainClass> collection,
                               SourceBase<TDomainClass> source,
                               bool loadWhenCreated = false)
        {
            _source = source;
            _collection = collection;
            Modified = true;

            if (loadWhenCreated)
            {
                Load();
            }
        }

        /// <summary>
        /// Returns a List containing all domain objects
        /// </summary>
        public List<TDomainClass> All
        {
            get { return _collection?.All; }
        }

        public bool Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        /// <summary>
        /// Inserts a single domain object into the model
        /// </summary>
        /// <param name="obj">
        /// Domain object to insert
        /// </param>
        public void Insert(TDomainClass obj)
        {
            _collection?.Insert(obj);
            Modified = true;
        }

        /// <summary>
        /// Deletes a single domain object from the model
        /// </summary>
        /// <param name="key">
        /// Key for object to delete.
        /// </param>
        /// <returns>
        /// Returns true if an object was actually deleted.
        /// </returns>
        public bool Delete(int key)
        {
            if (_collection != null)
            {
                Modified = _collection.Delete(key);
            }
            return Modified;
        }

        /// <summary>
        /// Deletes all domain objects from the model unconditionally.
        /// </summary>
        public void DeleteAll()
        {
            _collection?.DeleteAll();
        }

        /// <summary>
        /// Retrieves the object corresponding to the given key
        /// </summary>
        /// <param name="key">Key of object to retrieve</param>
        /// <returns>The domain object corresponding to the given key</returns>
        public TDomainClass Read(int key)
        {
            return _collection.Read(key);
        }

        /// <summary>
        /// Loads domain objects from the source.
        /// NB: Note that exceptions are catched and ignored - TODO
        /// </summary>
        public async void Load()
        {
            try
            {
                _collection = await _source.Load();
            }
            catch (Exception)
            {
                // ignored
            }
            Modified = true;
        }

        /// <summary>
        /// Saves domain objects back to the source.
        /// </summary>
        public void Save()
        {
            _source?.Save(_collection);
        }
    }
}
