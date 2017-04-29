using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Popups;
#pragma warning disable CS4014

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
                if (!_model.ContainsTitle(value))
                {
                    // Get note with existing title
                    if (_masterDetailsViewModel.ItemViewModelSelected != null)
                    {
                        Note aNote = _masterDetailsViewModel.ItemViewModelSelected.DomainObject;

                        // Create a new Note with changed Title
                        string content = aNote.Content;
                        _model.Delete(aNote.Title);
                        _model.Add(new Note(value, content));

                        // Invoke re-read of item collection
                        OnPropertyChanged();
                        _masterDetailsViewModel.OnItemViewModelCollectionChanged();

                        // Set item selection to item with updated title
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
                else
                {
                    var messageDialog = new MessageDialog("Add Note");
                    messageDialog.Content = "A note with the title " + value + " already exists!\n" + "Please use a different title.";
                    messageDialog.Commands.Add(new UICommand("OK", command => { OnPropertyChanged(); }));
                    messageDialog.ShowAsync();
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