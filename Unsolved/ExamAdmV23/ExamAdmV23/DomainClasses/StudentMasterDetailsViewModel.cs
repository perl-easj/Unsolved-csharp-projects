using ExamAdmV23.BaseClasses;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExamAdmV23.DomainClasses
{
    public class StudentMasterDetailsViewModel : INotifyPropertyChanged
    {
        private StudentModel _studentModel;
        private StudentItemViewModel _studentItemViewModelSelected;
        private StudentMasterViewModel _studentMasterViewModel;
        private RelayCommand _deleteCommand;

        public StudentMasterDetailsViewModel()
        {
            _studentModel = new StudentModel();
            _studentMasterViewModel = new StudentMasterViewModel();
            _deleteCommand = new RelayCommand(DoDelete, CanDelete);
            _studentItemViewModelSelected = null;
        }

        public ICommand DeletionCommand
        {
            get { return _deleteCommand; }
        }

        public bool CanDelete()
        {
            return (StudentItemViewModelSelected != null);
        }

        public void DoDelete()
        {
            Delete(StudentItemViewModelSelected.Name);
        }

        public List<StudentItemViewModel> StudentItemViewModelCollection
        {
            get { return _studentMasterViewModel.GetStudentItemViewModelCollection(_studentModel); }
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

        public void Delete(string name)
        {
            // Delete from model model
            _studentModel.Delete(name);

            // Set selection to null
            StudentItemViewModelSelected = null;

            // Refresh the item list
            OnPropertyChanged(nameof(StudentItemViewModelCollection));
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