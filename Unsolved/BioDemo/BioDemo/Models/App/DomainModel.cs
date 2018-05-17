using BioDemo.Models.Doman;

namespace BioDemo.Models.App
{
    /// <summary>
    /// This class represents the entire domain model, defined as consisting
    /// of the set of catalogs in which domain objects are stored.
    /// </summary>
    public class DomainModel
    {
        #region Instance fields
        private MovieCatalog _movieCatalog;
        private TheaterCatalog _theaterCatalog;
        private ShowCatalog _showCatalog;
        #endregion

        #region Singleton implementation
        private static DomainModel _instance;
        public static DomainModel Instance
        {
            get
            {
                _instance = _instance ?? (_instance = new DomainModel());
                return _instance;
            }
        }
        #endregion

        #region Constructor
        private DomainModel()
        {
            _movieCatalog = new MovieCatalog();
            _theaterCatalog = new TheaterCatalog();
            _showCatalog = new ShowCatalog();
        }
        #endregion

        #region Properties
        public MovieCatalog Movies { get { return _movieCatalog; } }
        public TheaterCatalog Theaters { get { return _theaterCatalog; } }
        public ShowCatalog Shows { get { return _showCatalog; } }
        #endregion

        #region Persistency methods
        public async void LoadAsync()
        {
            await _movieCatalog.LoadAsync();
            await _theaterCatalog.LoadAsync();
            await _showCatalog.LoadAsync();
        }

        public async void SaveAsync()
        {
            await _movieCatalog.SaveAsync();
            await _theaterCatalog.SaveAsync();
            await _showCatalog.SaveAsync();
        }
        #endregion
    }
}