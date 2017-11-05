using System.Windows.Input;
using Command.Implementation;
using DataTransformation.Interfaces;
using MVVMExample03.Model;
using MVVMExample03.Transformation;
using ViewModel.Implementation;

namespace MVVMExample03.ViewModel
{
    /// <summary>
    /// This class will act as Data Context for the Movie view. The class
    /// inherits from MasterDetailsViewModelBase, which does not assume a
    /// specific way of interaction between the elements, nor availability
    /// of any specific commands. The class must therefore itself implement:
    /// 1) A Delete functionality and command
    /// 2) A proper way of reacting to changes in item selection
    /// </summary>
    public class MasterDetailsViewModel : MasterDetailsViewModelBase<Movie, MovieViewModel>
    {
        #region Constructor
        /// <summary>
        /// Creates the Delete command object, and sets a 
        /// callback for handling changes in item selected.
        /// </summary>
        public MasterDetailsViewModel() : base(new ViewModelFactory(), new MovieCatalog())
        {
            _deleteCommand = new RelayCommand(DeleteMovie, CanDeleteMovie);
            ItemSelectionChanged += ItemSelectionChangedHandler;
        } 
        #endregion

        #region Implementation of Delete functionality
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
                Catalog.Delete(ItemSelected.DataObject.Key);
                OnPropertyChanged(nameof(ItemCollection));
            }
        }

        // Delete is only allowed if an item is selected.
        private bool CanDeleteMovie()
        {
            return ItemSelected != null;
        }
        #endregion

        #region Item selection changed handler
        /// <summary>
        /// This method will be called whenever the 
        /// item selection in the view changes.
        /// </summary>
        /// <param name="dataWrapper">Reference to new selection</param>
        private void ItemSelectionChangedHandler(IDataWrapper<MovieViewModel> dataWrapper)
        {
            // Notify the Delete command object that the
            // "executability" of the command may have changed
            _deleteCommand.RaiseCanExecuteChanged();

            // Set the ItemDetails property (defined in the 
            // base class) to refer to the new selected item
            // (or null if no item is selected).
            ItemDetails = dataWrapper == null ? null : ViewModelFactory.CreateDetailsViewModel(dataWrapper.DataObject);
        } 
        #endregion
    }
}