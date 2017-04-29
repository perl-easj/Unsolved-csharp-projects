using System.Threading.Tasks;
using MVVMStarter.Common;
using MVVMStarter.Models.Base;
using MVVMStarter.Persistency.App;

namespace MVVMStarter.Persistency.Base
{
    /// <summary>
    /// Base class for file-based sources.
    /// </summary>
    /// <typeparam name="TDomainClass">
    /// Type of domain objects to use with this source.
    /// </typeparam>
    class FileSourceBase<TDomainClass> : SourceBase<TDomainClass>
        where TDomainClass : DomainClassBase
    {
        private string _fileName;

        /// <summary>
        /// Data is stored in a text file called (NameOfDomainClass)Model.dat,
        /// for instance PhotoModel.dat
        /// </summary>
        public FileSourceBase()
        {
            _fileName = typeof(TDomainClass).Name + "Model.dat";
        }

        /// <summary>
        /// Reads domain objects from file
        /// </summary>
        /// <returns>
        /// Collection of domain objects
        /// </returns>
        public override async Task<CollectionBase<TDomainClass>> Load()
        {
            return await FilePersistency<TDomainClass>.Load(_fileName);
        }

        /// <summary>
        /// Saves domain objects to file
        /// </summary>
        /// <param name="collection">
        /// Collection of domain objects to save
        /// </param>
        public override void Save(CollectionBase<TDomainClass> collection)
        {
            FilePersistency<TDomainClass>.Save(collection, _fileName);
        }
    }
}
