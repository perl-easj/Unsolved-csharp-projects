using System.ComponentModel;
using System.Runtime.CompilerServices;
using Extensions.Model.Implementation;

namespace MVVMEx01.Model
{
    /// <summary>
    /// The MovieCatalog class acts both as a Domain object collection,
    /// and as Data Context for the Movie View. It therefore needs to
    /// implement INotifyPropertyChanged. 
    /// </summary>
    public class MovieCatalog : FilePersistableCatalogWithoutTransformation<Movie>, INotifyPropertyChanged
    {
        #region Constructor
        /// <summary>
        /// Constructor just adds some domain objects
        /// directly to the Catalog
        /// </summary>
        public MovieCatalog()
        {
            Create(new Movie("Alien", 1979));
            Create(new Movie("Terminator", 1984));
            Create(new Movie("Inception", 2010));
            Create(new Movie("Se7en", 1995));
            Create(new Movie("Arrival", 2016));
        }
        #endregion

        #region Code for keeping track of ItemSelected
        private Movie _itemSelected;

        /// <summary>
        /// ListView can bind its SelectedItem property
        /// to this property
        /// </summary>
        public Movie ItemSelected
        {
            get { return _itemSelected; }
            set
            {
                _itemSelected = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region INotifyPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
