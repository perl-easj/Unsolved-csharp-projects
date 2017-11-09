using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExamAdmV23.BaseClasses
{
    /// <summary>
    /// This class is intended to be a base class for a MasterDetails 
    /// view model classes. A domain-specific class must inherit from
    /// this class, and call its constructor with a domain-specific 
    /// catalog object and a domain-specific factory object.
    /// </summary>
    public abstract class MasterDetailsViewModelBase<TDomainClass, TKey> : INotifyPropertyChanged
        where TDomainClass : DomainClassBase<TKey>
    {
        #region Instance fields
        private ViewModelFactoryBase<TDomainClass, TKey> _factory;
        private CatalogBase<TDomainClass, TKey> _catalog;
        private ItemViewModelBase<TDomainClass> _itemViewModelSelected;
        private MasterViewModelBase<TDomainClass, TKey> _masterViewModel;
        private DeleteCommandBase<TDomainClass, MasterDetailsViewModelBase<TDomainClass, TKey>, TKey> _deleteCommand;
        #endregion

        #region Constructor
        /// <summary>
        /// Create the MasterDetails view model object, with 
        /// references to a catalog object and a factory object
        /// </summary>
        protected MasterDetailsViewModelBase(
            ViewModelFactoryBase<TDomainClass, TKey> factory,
            CatalogBase<TDomainClass, TKey> catalog)
        {
            _factory = factory;
            _catalog = catalog;
            _itemViewModelSelected = null;
            _masterViewModel = factory.CreateMasterViewModel();
            _deleteCommand = new DeleteCommandBase<TDomainClass, MasterDetailsViewModelBase<TDomainClass, TKey>, TKey>(this);
        }
        #endregion

        #region Properties for Data Binding
        /// <summary>
        /// Deletion command property. The view can bind 
        /// to this property.
        /// </summary>
        public ICommand DeletionCommand
        {
            get { return _deleteCommand; }
        }

        /// <summary>
        /// Get a collection of item view models.
        /// The view can bind to this property
        /// </summary>
        public List<ItemViewModelBase<TDomainClass>> ItemViewModelCollection
        {
            get { return _masterViewModel.GetItemViewModelCollection(_catalog, _factory); }
        }

        /// <summary>
        /// The item view model currently selected.
        /// The view can bind to this property
        /// </summary>
        public ItemViewModelBase<TDomainClass> ItemViewModelSelected
        {
            get { return _itemViewModelSelected; }
            set
            {
                _itemViewModelSelected = value;
                _deleteCommand.RaiseCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Performs the deletion of a domain object from the catalog,
        /// and triggers a re-read of item view models
        /// </summary>
        /// <param name="key">Key for object to delete</param>
        public void Delete(TKey key)
        {
            // Delete from model collection
            _catalog.Delete(key);

            // Set selection to null
            ItemViewModelSelected = null;

            // Refresh the item list
            OnPropertyChanged(nameof(ItemViewModelCollection));
        } 
        #endregion

        #region OnPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}