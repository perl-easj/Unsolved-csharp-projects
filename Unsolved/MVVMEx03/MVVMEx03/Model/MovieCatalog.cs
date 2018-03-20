using Extensions.Model.Implementation;

namespace MVVMEx03.Model
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
            Create(new Movie("Alien", 1979));
            Create(new Movie("Terminator", 1984));
            Create(new Movie("Inception", 2010));
            Create(new Movie("Se7en", 1995));
            Create(new Movie("Arrival", 2016));
        }
        #endregion        
    }
}