using System.Collections.Generic;
using Catalog.Implementation;
using DataTransformation.Implementation;
using InMemoryStorage.Implementation;
using MVVMExample04.Transformation;

namespace MVVMExample04.Model
{
    /// <summary>
    /// The MovieCatalog now inherits from the PersistableCatalog class,
    /// buts uses a simplified setup:
    /// 1) No actual data source (second parameter to base class constructor
    ///    is null, and list of supported persistency operations is empty).
    /// 2) No actual Factory from domain to DTO, since no source is used.
    /// Note that the class now follows the Singleton pattern
    /// </summary>
    public class MovieCatalog : PersistableCatalog<Movie, MovieViewModel, Movie>
    {
        #region Model Singleton implementation
        private static MovieCatalog _instance;

        public static MovieCatalog Instance
        {
            get
            {
                _instance = _instance ?? new MovieCatalog();
                return _instance;
            }
        }
        #endregion

        private MovieCatalog()
            : base(new InMemoryCollection<Movie>(), null,
                new MovieViewModelFactory(), new IdenticalDataFactory<Movie>(),
                new List<Persistency.Interfaces.PersistencyOperations>())
        {
            MovieViewModelFactory factory = new MovieViewModelFactory();
            Create(factory.CreateTransformedObject(new Movie("Alien", 1979, 112, 1)));
            Create(factory.CreateTransformedObject(new Movie("Terminator", 1984, 98, 2)));
            Create(factory.CreateTransformedObject(new Movie("Inception", 2010, 135, 1)));
            Create(factory.CreateTransformedObject(new Movie("Se7en", 1995, 108, 2)));
            Create(factory.CreateTransformedObject(new Movie("Arrival", 2016, 126, 2)));
        }
    }
}