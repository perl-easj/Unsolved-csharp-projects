using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoteBook
{
    public class NoteDetailsViewModel : INotifyPropertyChanged
    {
        public Note DomainObject;
        private NoteMasterDetailsViewModel _masterDetailsViewModel;
        private NoteModel _model;

        public NoteDetailsViewModel(Note obj, NoteMasterDetailsViewModel masterDetailsViewModel, NoteModel model)
        {
            DomainObject = obj;
            _masterDetailsViewModel = masterDetailsViewModel;
            _model = model;
        }

        public string Title
        {
            get { return DomainObject.Title; }
            set
            {
                // Need to validate new title against existing titles
                if (_masterDetailsViewModel.ValidateTitle(value))
                {
                    // Get note with existing title
                    if (_masterDetailsViewModel.ItemViewModelSelected != null)
                    {
                        Note aNote = _model.Read(_masterDetailsViewModel.ItemViewModelSelected.DomainObject.Title);
                        if (aNote != null)
                        {
                            // Create a new Note with changed Title
                            string content = aNote.Content;
                            _model.Delete(aNote.Title);
                            _model.Add(new Note(value, content));

                            OnPropertyChanged();
                            _masterDetailsViewModel.OnItemViewModelCollectionChanged();

                            foreach (var ivm in _masterDetailsViewModel.ItemViewModelCollection)
                            {
                                if (ivm.DomainObject.Title == value)
                                {
                                    _masterDetailsViewModel.ItemViewModelSelected = ivm;
                                }
                            }

                            _masterDetailsViewModel.NotifyCommands();
                        }
                    }
                }

                OnPropertyChanged();
            }
        }

        public string Content
        {
            get { return DomainObject.Content; }
            set
            {
                DomainObject.Content = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}