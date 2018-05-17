using Data.InMemory.Interfaces;
using Extensions.Model.Implementation;

namespace BioDemo.Models.Base
{
    /// <summary>
    /// This class will be a base class for all catalog classes.
    /// This is preferred instead of letting catalog classes inherit
    /// directly from a specific library catalog class, since we can
    /// then change inheritance setup for all catalog classes by
    /// changing this single base class.
    /// 
    /// The catalogs are currently set to using file-based persistency.
    /// </summary>
    /// <typeparam name="T">Type of objects stored in the Catalog</typeparam>
    public class CatalogAppBase<T> : FilePersistableCatalogWithoutTransformationAsync<T>
        where T : class, IStorable, ICopyable, new()
    {
    }
}