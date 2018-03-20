using Extensions.Model.Implementation;

namespace MVVMEx04.Model
{
    /// <summary>
    /// This class is now a "pure" catalog class, 
    /// i.e. no view-related responsibilities.
    /// </summary>
    public class MovieCatalog : FilePersistableCatalogWithoutTransformation<Movie>
    {
        #region Constructor
        public MovieCatalog()
        {
            // Add some domain objects directly to the Catalog
            Create(new Movie("Alien", 1979, 112, "Paramount"));
            Create(new Movie("Terminator", 1984, 96, "20th Century Fox"));
            Create(new Movie("Inception", 2010, 143, "New Line Cinema"));
            Create(new Movie("Se7en", 1995, 124, "Paramount"));
            Create(new Movie("Arrival", 2016, 130, "20th Century Fox"));
        }
        #endregion        
    }
}