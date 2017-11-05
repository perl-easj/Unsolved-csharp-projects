using ExtensionsModel.Implementation;
using MVVMExample05.DataTransformation.Domain.Movie;

namespace MVVMExample05.Models.Domain.Movie
{
    public class MovieCatalog : FilePersistableCatalogNoDTO<Movie, MovieViewModel>
    {
        #region Model Singleton implementation
        private static MovieCatalog _instance;

        public static MovieCatalog Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = new MovieCatalog();
                return _instance;
            }
        }

        private MovieCatalog() : base(new MovieViewModelFactory())
        {
        }
        #endregion
    }
}