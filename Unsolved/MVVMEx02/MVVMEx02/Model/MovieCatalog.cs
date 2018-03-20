using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Commands.Implementation;
using Data.Transformed.Interfaces;
using Extensions.Model.Implementation;

namespace MVVMEx02.Model
{
    /// <summary>
    /// The MovieCatalog class acts both as a Domain object collection,
    /// a Data Context for the Movie View, and a data source for a
    /// deletion command. It therefore needs to implement IDataWrapper
    /// and INotifyPropertyChanged interfaces.
    /// (Warning: Number of responsibilities is growing...)
    /// </summary>
    public class MovieCatalog : FilePersistableCatalogWithoutTransformation<Movie>, IDataWrapper<Movie>, INotifyPropertyChanged
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

            // The Catalog also acts as a data wrapper, which is
            // why the first argument is also "this"
            _deleteCommand = new DeleteCommandBase<Movie>(this, this, () => _itemSelected != null);

            // When the Catalog content changes (i.e. when something is deleted,
            // call OnPropertyChanged for the All property, so those binding to
            // this property are notified of the change.
            CatalogChanged += i => OnPropertyChanged(nameof(All));
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
        #endregion

        #region Code for enabling a Delete functionality
        private DeleteCommandBase<Movie> _deleteCommand;

        // View can bind e.g. the Action property of a Button
        // to this property
        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
        }

        // Implementation of IDataWrapper interface
        public Movie DataObject
        {
            get { return _itemSelected; }
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