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
    public abstract class MasterDetailsViewModelBase<TDomainClass> : INotifyPropertyChanged
        where TDomainClass : DomainClassBase
    {
        #region Instance fields
        private CatalogBase<TDomainClass> _catalog;
        private ViewModelFactoryBase<TDomainClass> _factory;
        private ItemViewModelBase<TDomainClass> _itemViewModelSelected;
        private DeleteCommandBase<TDomainClass, MasterDetailsViewModelBase<TDomainClass>> _deleteCommand;
        #endregion

        #region Constructor
        /// <summary>
        /// Create the MasterDetails view model object, with 
        /// references to a catalog object and a factory object
        /// </summary>
        protected MasterDetailsViewModelBase(
            CatalogBase<TDomainClass> catalog,
            ViewModelFactoryBase<TDomainClass> factory)
        {
            _catalog = catalog;
            _factory = factory;
            _itemViewModelSelected = null;
            _deleteCommand = new DeleteCommandBase<TDomainClass, MasterDetailsViewModelBase<TDomainClass>>(_catalog, this);
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
            get { return _factory.GetItemViewModelCollection(_catalog); }
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
        public void RefreshItemViewModelCollection()
        {
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