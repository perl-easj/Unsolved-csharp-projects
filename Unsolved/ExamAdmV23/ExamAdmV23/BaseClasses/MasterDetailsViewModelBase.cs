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
    /// model object and a domain-specific factory object.
    /// </summary>
    public abstract class MasterDetailsViewModelBase<TDomainClass, TKey> : INotifyPropertyChanged
        where TDomainClass : DomainClassBase<TKey>
    {
        private ViewModelFactoryBase<TDomainClass, TKey> _factory;
        private ModelBase<TDomainClass, TKey> _model;
        private ItemViewModelBase<TDomainClass> _itemViewModelSelected;
        private MasterViewModelBase<TDomainClass, TKey> _masterViewModel;
        private RelayCommand _deleteCommand;

        /// <summary>
        /// Create the MasterDetails view model object, with 
        /// references to a model object and a factory object
        /// </summary>
        protected MasterDetailsViewModelBase(
            ViewModelFactoryBase<TDomainClass, TKey> factory,
            ModelBase<TDomainClass, TKey> model)
        {
            _factory = factory;
            _model = model;
            _masterViewModel = factory.CreateMasterViewModel();
            _deleteCommand = new RelayCommand(DoDelete, CanDelete);
            _itemViewModelSelected = null;
        }

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
            get { return _masterViewModel.GetItemViewModelCollection(_model, _factory); }
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

        /// <summary>
        /// Private method for use in DeleteCommand
        /// </summary>
        private bool CanDelete()
        {
            return (ItemViewModelSelected != null);
        }

        /// <summary>
        /// Private method for use in DeleteCommand
        /// </summary>
        private void DoDelete()
        {
            Delete(ItemViewModelSelected.DomainObject.Key);
        }

        /// <summary>
        /// Performs the deletion of a domain object from the model,
        /// and triggers a re-read of item view models
        /// </summary>
        /// <param name="key">Key for object to delete</param>
        private void Delete(TKey key)
        {
            // Delete from model collection
            _model.Delete(key);

            // Set selection to null
            ItemViewModelSelected = null;

            // Refresh the item list
            OnPropertyChanged(nameof(ItemViewModelCollection));
        }

        #region OnPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}