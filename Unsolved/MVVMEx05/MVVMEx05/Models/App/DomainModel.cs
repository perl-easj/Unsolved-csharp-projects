using System;
using MVVMEx05.Data.Domain;
using MVVMEx05.Models.Domain;

namespace MVVMEx05.Models.App
{
    /// <summary>
    /// This class represents the entire domain model, and includes all elements
    /// (events, properties and methods,) relating to the entire domain model.
    /// The class is a Singleton.
    /// </summary>
    public class DomainModel
    {
        #region Instance fields
        private MovieCatalog _movieCatalog;
        private StudioCatalog _studioCatalog;
        #endregion

        #region Events
        public event Action LoadBegins;
        public event Action LoadEnds;
        public event Action SaveBegins;
        public event Action SaveEnds;
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

        public static DomainModel Catalogs { get { return Instance; } }
        #endregion

        #region Constructor
        /// <summary>
        /// For convenience, the constructor creates some sample Movie
        /// and Studio domain objects, and adds them to the catalogs.
        /// </summary>
        private DomainModel()
        {
            _movieCatalog = new MovieCatalog();
            _studioCatalog = new StudioCatalog();

            _movieCatalog.Create(new Movie(0, "Alien", 1979, 112, "Paramount"));
            _movieCatalog.Create(new Movie(1, "Terminator", 1984, 96, "20th Century Fox"));
            _movieCatalog.Create(new Movie(2, "Inception", 2010, 143, "New Line Cinema"));
            _movieCatalog.Create(new Movie(3, "Se7en", 1995, 124, "Paramount"));
            _movieCatalog.Create(new Movie(4, "Arrival", 2016, 130, "20th Century Fox"));

            _studioCatalog.Create(new Studio(5, "Paramount", "New York", 8000));
            _studioCatalog.Create(new Studio(6, "20th Century Fox", "New York", 2500));
            _studioCatalog.Create(new Studio(7, "New Line Cinema", "Boston", 4000));
        }
        #endregion

        #region Properties
        public MovieCatalog Movies { get { return _movieCatalog; } }
        public StudioCatalog Studios { get { return _studioCatalog; } }
        #endregion

        #region Persistency methods
        public async void LoadModel()
        {
            // Notifies subscribers that Load is about to start
            LoadBegins?.Invoke();

            await _movieCatalog.LoadAsync();
            await _studioCatalog.LoadAsync();

            // Notifies subscribers that Load is about to end
            LoadEnds?.Invoke();
        }

        public async void SaveModel()
        {
            // Notifies subscribers that Save is about to start
            SaveBegins?.Invoke();

            await _movieCatalog.SaveAsync();
            await _studioCatalog.SaveAsync();

            // Notifies subscribers that Save is about to end
            SaveEnds?.Invoke();
        }
        #endregion
    }
}