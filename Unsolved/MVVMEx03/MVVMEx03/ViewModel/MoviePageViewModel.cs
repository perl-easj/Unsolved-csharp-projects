using System.Windows.Input;
using Commands.Implementation;
using Data.Transformed.Interfaces;
using MVVMEx03.Model;
using ViewModel.Page.Implementation;

namespace MVVMEx03.ViewModel
{
    /// <summary>
    /// This class acts as a Data Context for the View. Since the base class
    /// does not include any commands, nor any specific handling of e.g. a
    /// change in item selection, these elements must be addded explicitly
    /// to the implementation.
    /// </summary>
    public class MoviePageViewModel : PageViewModelBase<Movie>
    {
        #region Instance fields
        private DeleteCommandBase<Movie> _deleteCommand;
        #endregion

        #region Constructor
        public MoviePageViewModel() : base(new MovieCatalog())
        {
            // Initialise the delete Command object with a source (the page view model itself),
            // a target (the aggregated Catalog), and a condition (an item must be selected)
            _deleteCommand = new DeleteCommandBase<Movie>(this, Catalog, () => ItemSelected != null);

            // Define how to react to changes in item selection
            ItemSelectionChanged += ItemSelectionChangedHandler;

            // Define how to react to changes in aggregated catalog
            Catalog.CatalogChanged += CatalogChangedHandler;
        }
        #endregion

        #region Properties
        // View can bind e.g. the Action property of a Button
        // to this property
        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
        }
        #endregion

        #region Methods
        // Implementation of abstract method from base class
        public override IDataWrapper<Movie> CreateDataViewModel(Movie obj)
        {
            return new MovieDataViewModel(obj);
        }

        // Handling of changes in item selection
        private void ItemSelectionChangedHandler(IDataWrapper<Movie> dataWrapper)
        {
            // Item details is "slaved" to selected item
            ItemDetails = ItemSelected;

            // Notify the Delete command object that the
            // "executability" of the command may have changed
            _deleteCommand.RaiseCanExecuteChanged();
        }

        // Handling of changes in Catalog (notify any view 
        // properties binding to ItemCollection).
        private void CatalogChangedHandler(int key)
        {
            OnPropertyChanged(nameof(ItemCollection));
        }
        #endregion
    }
}