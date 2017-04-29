using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Popups;
#pragma warning disable CS4014

namespace NoteBook
{
    public class NoteMasterDetailsViewModel : INotifyPropertyChanged
    {
        #region Instance fields
        private NoteModel _model;
        private NoteSource _source;
        private Note _selectedNote;

        private RelayCommand _loadCommand;
        private RelayCommand _saveCommand;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        #endregion

        #region Data properties
        public ObservableCollection<Note> ItemCollection
        {
            get
            {
                ObservableCollection<Note> items = new ObservableCollection<Note>();

                foreach (Note aNote in _model.All)
                {
                    items.Add(aNote);
                }

                return items;
            }
        }

        public Note SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                _selectedNote = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NoteTitle));
                OnPropertyChanged(nameof(NoteContent));
                NotifyCommands();
            }
        }

        public string NoteTitle
        {
            get
            {
                return _selectedNote != null ? _selectedNote.Title : string.Empty;
            }
            set
            {
                // Need to validate new title against existing titles
                if (ValidateTitle(value))
                {
                    // Get note with existing title
                    if (_selectedNote != null)
                    {
                        Note aNote = _model.Read(_selectedNote.Title);
                        if (aNote != null)
                        {
                            // Create a new Note with changed Title
                            string content = aNote.Content;
                            _model.Delete(aNote.Title);
                            _model.Add(new Note(value, content));

                            OnPropertyChanged();
                            OnPropertyChanged(nameof(ItemCollection));
                            SelectedNote = _model.Read(value);
                            NotifyCommands();
                        }
                    }
                }
            }
        }

        public string NoteContent
        {
            get
            {
                return _selectedNote != null ? _selectedNote.Content : string.Empty;
            }
            set
            {
                if (_selectedNote != null)
                {
                    _selectedNote.Content = value;
                }

                OnPropertyChanged();
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
            _selectedNote = null;

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
            DeleteNote(_selectedNote.Title);
            NotifyCommands();
        }

        private async void Load()
        {
            await _source.Load(_model);
            OnPropertyChanged(nameof(ItemCollection));
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
            return _selectedNote != null;
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
        private void NotifyCommands()
        {
            _addCommand.RaiseCanExecuteChanged();
            _deleteCommand.RaiseCanExecuteChanged();
            _loadCommand.RaiseCanExecuteChanged();
            _saveCommand.RaiseCanExecuteChanged();
        }

        private bool ValidateTitle(string title)
        {
            if (_model.ContainsTitle(title))
            {
                ReportExistingTitle(title);
                return false;
            }

            return true;
        }

        private void ReportExistingTitle(string name)
        {
            var messageDialog = new MessageDialog("Add Note");
            messageDialog.Content = "A note with the title " + name + " already exists!\n" + "Please use a different title.";
            messageDialog.Commands.Add(new UICommand("OK", command => { OnPropertyChanged(nameof(NoteTitle)); }));
            messageDialog.ShowAsync();
        }

        private void AddNote(Note aNote)
        {
            _model.Add(aNote);
            OnPropertyChanged(nameof(ItemCollection));
        }

        private void DeleteNote(string title)
        {
            _model.Delete(title);
            OnPropertyChanged(nameof(ItemCollection));
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
