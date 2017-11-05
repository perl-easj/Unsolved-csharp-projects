using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Catalog.Implementation;
using Command.Implementation;

namespace MVVMExample02.Model
{
    /// <summary>
    /// The MovieCatalog class acts both as a Domain object collection,
    /// and as Data Context for the Movie View. It therefore needs
    /// to implement INotifyPropertyChanged.
    /// </summary>
    public class MovieCatalog : InMemoryCatalog<Movie>, INotifyPropertyChanged
    {
        #region Pure Catalog implementation
        /// <summary>
        /// Constructor just adds some domain objects
        /// directly to the Catalog, and initialises
        /// the Command property
        /// </summary>
        public MovieCatalog()
        {
            Create(new Movie("Alien", 1979));
            Create(new Movie("Terminator", 1984));
            Create(new Movie("Inception", 2010));
            Create(new Movie("Se7en", 1995));
            Create(new Movie("Arrival", 2016));

            _deleteCommand = new RelayCommand(DeleteMovie, CanDeleteMovie);
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

                // Notify the Delete command object that the
                // "executability" of the command may have changed
                _deleteCommand.RaiseCanExecuteChanged();
            }
        }

        // Standard INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Code for implementing a Delete functionality
        private RelayCommand _deleteCommand;

        // View can bind e.g. the Action property of a Button
        // to this property
        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
        }

        // Deletion functionality
        private void DeleteMovie()
        {
            if (CanDeleteMovie())
            {
                Delete(_itemSelected.Key);
                OnPropertyChanged(nameof(All));
            }
        }

        // Delete is only allowed if an item is selected.
        private bool CanDeleteMovie()
        {
            return _itemSelected != null;
        }
        #endregion
    }
}