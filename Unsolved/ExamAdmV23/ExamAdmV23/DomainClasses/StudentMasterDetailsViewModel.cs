using ExamAdmV23.BaseClasses;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExamAdmV23.DomainClasses
{
    public class StudentMasterDetailsViewModel : INotifyPropertyChanged
    {
        #region Instance fields
        private StudentCatalog _studentCatalog;
        private StudentItemViewModel _studentItemViewModelSelected;
        private StudentMasterViewModel _studentMasterViewModel;
        private DeleteCommand _deleteCommand;
        #endregion

        #region Constructor
        public StudentMasterDetailsViewModel()
        {
            _studentCatalog = new StudentCatalog();
            _studentMasterViewModel = new StudentMasterViewModel();
            _deleteCommand = new DeleteCommand(this);
            _studentItemViewModelSelected = null;
        }
        #endregion

        #region Properties for Data Binding
        public ICommand DeletionCommand
        {
            get { return _deleteCommand; }
        }

        public List<StudentItemViewModel> StudentItemViewModelCollection
        {
            get { return _studentMasterViewModel.GetStudentItemViewModelCollection(_studentCatalog); }
        }

        public StudentItemViewModel StudentItemViewModelSelected
        {
            get { return _studentItemViewModelSelected; }
            set
            {
                _studentItemViewModelSelected = value;
                _deleteCommand.RaiseCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        public void Delete(string name)
        {
            // Delete from catalog
            _studentCatalog.Delete(name);

            // Set selection to null
            StudentItemViewModelSelected = null;

            // Refresh the item list
            OnPropertyChanged(nameof(StudentItemViewModelCollection));
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