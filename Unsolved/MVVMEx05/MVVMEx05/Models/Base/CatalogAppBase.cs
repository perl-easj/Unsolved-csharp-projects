using Data.InMemory.Interfaces;
using Extensions.Model.Implementation;

namespace MVVMEx05.Models.Base
{
    /// <summary>
    /// Base class for catalogs used in this application.
    /// Currently set to using file-based persistency.
    /// </summary>
    public class CatalogAppBase<T> : FilePersistableCatalogWithoutTransformationAsync<T>
        where T : class, IStorable, ICopyable, new()
    {
        public CatalogAppBase() : base()
        {
        }
    }
}