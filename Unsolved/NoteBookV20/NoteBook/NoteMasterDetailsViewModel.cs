using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

#pragma warning disable CS4014

namespace NoteBook
{
    public class NoteMasterDetailsViewModel : INotifyPropertyChanged
    {
        #region Instance fields
        private NoteModel _model;
        private NoteSource _source;

        private NoteMasterViewModel _masterViewModel;
        private NoteDetailsViewModel _detailsViewModel;
        private NoteItemViewModel _itemViewModelSelected;

        private RelayCommand _loadCommand;
        private RelayCommand _saveCommand;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        #endregion

        #region Data properties
        public NoteDetailsViewModel DetailsViewModel
        {
            get { return _detailsViewModel; }
        }

        public ObservableCollection<NoteItemViewModel> ItemViewModelCollection
        {
            get { return _masterViewModel.createItemViewModelCollection(_model); }
        }

        public NoteItemViewModel ItemViewModelSelected
        {
            get { return _itemViewModelSelected; }
            set
            {
                _itemViewModelSelected = value;

                if (_itemViewModelSelected == null)
                {
                    _detailsViewModel = null;
                }
                else
                {
                    _detailsViewModel = new NoteDetailsViewModel(_itemViewModelSelected.DomainObject, this, _model);
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(DetailsViewModel));
                NotifyCommands();
            }
        }
        #endregion

        #region Command properties
        public ICommand LoadCommand
        {
            get { return _loadCommand; }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
        }

        public ICommand AddCommand
        {
            get { return _addCommand; }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
        }
        #endregion

        #region Constructor
        public NoteMasterDetailsViewModel()
        {
            _model = new NoteModel();
            _source = new NoteSource();

            _masterViewModel = new NoteMasterViewModel();
            _itemViewModelSelected = null;
            _detailsViewModel = null;

            _loadCommand = new RelayCommand(Load, CanLoad);
            _saveCommand = new RelayCommand(Save, CanSave);
            _addCommand = new RelayCommand(Add, CanAdd);
            _deleteCommand = new RelayCommand(Delete, CanDelete);
        } 
        #endregion

        #region Command implementations
        private void Add()
        {
            AddNote(new Note());
            NotifyCommands();
        }

        private void Delete()
        {
            DeleteNote(_itemViewModelSelected.DomainObject.Title);
            NotifyCommands();
        }

        private async void Load()
        {
            await _source.Load(_model);
            OnPropertyChanged(nameof(ItemViewModelCollection));
            NotifyCommands();
        }

        private async void Save()
        {
            await _source.Save(_model);
            NotifyCommands();
        }

        private bool CanAdd()
        {
            return !_model.ContainsTitle(Note.DefaultTitle);
        }

        private bool CanDelete()
        {
            return _itemViewModelSelected != null;
        }

        private bool CanLoad()
        {
            return true;
        }

        private bool CanSave()
        {
            return _model.All.Count > 0;
        }
        #endregion

        #region Helper methods
        public void OnItemViewModelCollectionChanged()
        {
            OnPropertyChanged(nameof(ItemViewModelCollection));
        }

        public void NotifyCommands()
        {
            _addCommand.RaiseCanExecuteChanged();
            _deleteCommand.RaiseCanExecuteChanged();
            _loadCommand.RaiseCanExecuteChanged();
            _saveCommand.RaiseCanExecuteChanged();
        }

        //public void UpdateTitle(string newTitle)
        //{
        //    try
        //    {
        //        // Update title, and invoke re-read of item collectiom
        //        _model.UpdateTitle(ItemViewModelSelected.DomainObject.Title, newTitle);
        //        OnPropertyChanged(nameof(ItemViewModelCollection));

        //        // Set item selection to item with updated title
        //        SetItemViewModelSelectedByTitle(newTitle);

        //        NotifyCommands();
        //    }
        //    catch (TitleExistsException e)
        //    {
        //        NoteErrorPresenter.ReportExistingTitle(e.Message, () => { OnPropertyChanged(nameof(DetailsViewModel)); });
        //    }
        //}

        private void SetItemViewModelSelectedByTitle(string title)
        {
            foreach (NoteItemViewModel itemViewModel in ItemViewModelCollection)
            {
                if (itemViewModel.DomainObject.Title == title)
                {
                    ItemViewModelSelected = itemViewModel;
                    return;
                }
            }
        }

        private void AddNote(Note aNote)
        {
            _model.Add(aNote);
            OnPropertyChanged(nameof(ItemViewModelCollection));
        }

        private void DeleteNote(string title)
        {
            _model.Delete(title);
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
