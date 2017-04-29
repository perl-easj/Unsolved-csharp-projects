using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml;
using MVVMStarter.Common;
using MVVMStarter.Controllers.Base;
using MVVMStarter.Models.Base;
using MVVMStarter.ViewModels.App;

namespace MVVMStarter.ViewModels.Base
{
    /// <summary>
    /// This class is a base class for any colllection-oriented view model, 
    /// i.e. a view model that wraps a collection of domain objects.
    /// </summary>
    /// <typeparam name="TDomainClass">
    /// Type of domain objects wrapped by the class.
    /// </typeparam>
    public abstract class MasterDetailsViewModelBase<TDomainClass> : INotifyPropertyChanged
        where TDomainClass : DomainClassBase, new()
    {
        #region Instance fields
        private DomainModelBase<TDomainClass> _domainModel;
        private ViewModelFactoryBase<TDomainClass> _viewModelFactory;
        
        private MasterViewModelBase<TDomainClass> _masterViewModel;
        private DetailsViewModelBase<TDomainClass> _detailsViewModel;
        private ItemViewModelBase<TDomainClass> _itemViewModelSelected;

        private ViewControlState.ViewState _viewState;
        private ViewControlStateManager _stateManager;

        private ControllerBase<TDomainClass> _deleteCommandController;
        private ControllerBase<TDomainClass> _updateCommandController;
        private ControllerBase<TDomainClass> _createCommandController;

        private RelayCommand _selectCreateCommand;
        private RelayCommand _selectReadCommand;
        private RelayCommand _selectUpdateCommand;
        private RelayCommand _selectDeleteCommand;
        #endregion

        #region Public properties for handlers
        public ViewControlState.ViewState ViewState
        {
            get { return _viewState; }
            set
            {
                _viewState = value;

                PrepareState();
                NotifyCommands();
                OnPropertyChanged(nameof(ViewControlStates));
                OnPropertyChanged(nameof(ItemSelectorEnabled));
                OnPropertyChanged(nameof(ItemSelectorVisible));
                OnPropertyChanged();
            }
        }
        #endregion

        #region Public properties for binding
        public virtual ObservableCollection<ItemViewModelBase<TDomainClass>> ItemViewModelCollection
        {
            get { return _masterViewModel.CreateItemViewModelCollection(_domainModel, _viewModelFactory); }
        }

        public virtual ItemViewModelBase<TDomainClass> ItemViewModelSelected
        {
            get { return _itemViewModelSelected; }
            set
            {
                _itemViewModelSelected = value;
                DetailsViewModel = CreateDetailsViewModel();

                NotifyCommands();
                OnPropertyChanged(nameof(DetailsViewModel));
                OnPropertyChanged();
            }
        }

        public virtual DetailsViewModelBase<TDomainClass> DetailsViewModel
        {
            get { return _detailsViewModel; }
            set
            {
                _detailsViewModel = value;
                NotifyCommands();
                OnPropertyChanged();
            }
        }

        private DetailsViewModelBase<TDomainClass> CreateDetailsViewModel()
        {
            if (_itemViewModelSelected == null)
            {
                return null;
            }
            else
            {
                return (ViewState == ViewControlState.ViewState.Update
                    ? _viewModelFactory.CreateDetailsViewModel((TDomainClass)ItemViewModelSelected.DomainObject.Clone())
                    : _viewModelFactory.CreateDetailsViewModel(ItemViewModelSelected.DomainObject));
            }
        }

        public Dictionary<string, ViewControlState> ViewControlStates
        {
            get  { return _stateManager.GetViewControlStates(ViewState); }
        }

        public virtual bool ItemSelectorEnabled
        {
            get { return (ViewState != ViewControlState.ViewState.Create); }
        }

        public virtual Visibility ItemSelectorVisible
        {
            get { return Visibility.Visible; }
        }
        #endregion

        #region Protected properties for derived classes
        protected ViewControlStateManager StateManager
        {
            get { return _stateManager; }
        }
        #endregion

        #region Initialisation
        protected MasterDetailsViewModelBase(ViewModelFactoryBase<TDomainClass> viewModelFactory,
                                             DomainModelBase<TDomainClass> domainModel)
        {
            _domainModel = domainModel;
            _viewModelFactory = viewModelFactory;

            _masterViewModel = _viewModelFactory.CreateMasterViewModel();
            _detailsViewModel = null; 
            _itemViewModelSelected = null;

            _stateManager = new ViewControlStateManager();
            _viewState = ViewControlState.ViewState.Read;

            SetupViewStateCommands();
            SetupViewActionControllers();
        }

        protected virtual void SetupViewStateCommands()
        {
            _selectCreateCommand = new RelayCommand(() => { ViewState = ViewControlState.ViewState.Create; }, () => true);
            _selectReadCommand = new RelayCommand(() => { ViewState = ViewControlState.ViewState.Read; }, () => true);
            _selectUpdateCommand = new RelayCommand(() => { ViewState = ViewControlState.ViewState.Update; }, () => true);
            _selectDeleteCommand = new RelayCommand(() => { ViewState = ViewControlState.ViewState.Delete; }, () => true);
        }

        protected virtual void SetupViewActionControllers()
        {
            _deleteCommandController = new DeleteControllerBase<TDomainClass>(this, _domainModel);
            _updateCommandController = new UpdateControllerBase<TDomainClass>(this, _domainModel);
            _createCommandController = new CreateControllerBase<TDomainClass>(this, _domainModel);
        }
        #endregion

        #region Helper methods
        private void PrepareState()
        {
            if (ViewState == ViewControlState.ViewState.Create)
            {
                DetailsViewModel = _viewModelFactory.CreateDetailsViewModel(new TDomainClass());
            }
            if (ViewState == ViewControlState.ViewState.Update && ItemViewModelSelected != null)
            {
                DetailsViewModel = _viewModelFactory.CreateDetailsViewModel((TDomainClass)ItemViewModelSelected.DomainObject.Clone());
            }
        }

        /// <summary>
        /// Notifies all commands that the CanExecute
        /// status may have changed.
        /// </summary>
        protected virtual void NotifyCommands()
        {
            _createCommandController.RaiseCanExecuteChanged();
            _updateCommandController.RaiseCanExecuteChanged();
            _deleteCommandController.RaiseCanExecuteChanged();
        }
        #endregion

        #region ICommand action controller properties
        public ICommand DeleteCommand
        {
            get { return _deleteCommandController; }
        }

        public ICommand UpdateCommand
        {
            get { return _updateCommandController; }
        }

        public ICommand CreateCommand
        {
            get { return _createCommandController; }
        }
        #endregion

        #region ICommand state properties
        public ICommand SelectCreateCommand
        {
            get { return _selectCreateCommand; }
        }

        public ICommand SelectReadCommand
        {
            get { return _selectReadCommand; }
        }

        public ICommand SelectUpdateCommand
        {
            get { return _selectUpdateCommand; }
        }

        public ICommand SelectDeleteCommand
        {
            get { return _selectDeleteCommand; }
        } 
        #endregion

        #region After... methods for handlers
        public virtual void AfterModelInsert(TDomainClass e)
        {
            AfterModelModified();
            DetailsViewModel = _viewModelFactory.CreateDetailsViewModel(new TDomainClass());
        }

        public virtual void AfterModelDelete(int key)
        {
            AfterModelModified();
        }

        public virtual void AfterModelUpdate(TDomainClass e)
        {
            AfterModelModified();
        }

        private void AfterModelModified()
        {
            ItemViewModelSelected = null;
            OnPropertyChanged(nameof(ItemViewModelCollection));
        }
        #endregion

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
