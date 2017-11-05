using System.Collections.Generic;
using Catalog.Implementation;
using DataTransformation.Implementation;
using InMemoryStorage.Implementation;
using MVVMExample03.Transformation;

namespace MVVMExample03.Model
{
    /// <summary>
    /// The MovieCatalog class now inherits from the general Catalog class,
    /// buts uses a simplified setup:
    /// 1) No actual data source (second parameter to base class constructor
    ///    is null, and list of supported persistency operations is empty).
    /// 2) No actual Factory from domain to DTO, since no source is used.
    /// </summary>
    public class MovieCatalog : Catalog<Movie, MovieViewModel, Movie>
    {
        public MovieCatalog() 
            : base(new InMemoryCollection<Movie>(), null, 
                  new MovieViewModelFactory(), new IdenticalDataFactory<Movie>(), 
                  new List<Persistency.Interfaces.PersistencyOperations>())
        {
            MovieViewModelFactory factory = new MovieViewModelFactory();
            Create(factory.CreateTransformedObject(new Movie("Alien", 1979)));
            Create(factory.CreateTransformedObject(new Movie("Terminator", 1984)));
            Create(factory.CreateTransformedObject(new Movie("Inception", 2010)));
            Create(factory.CreateTransformedObject(new Movie("Se7en", 1995)));
            Create(factory.CreateTransformedObject(new Movie("Arrival", 2016)));
        }
    }
}