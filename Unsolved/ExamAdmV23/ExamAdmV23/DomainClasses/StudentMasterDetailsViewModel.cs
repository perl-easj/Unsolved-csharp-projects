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
        private StudentViewModelFactory _factory;
        private StudentItemViewModel _studentItemViewModelSelected;
        private DeleteCommand _deleteCommand;
        #endregion

        #region Constructor
        public StudentMasterDetailsViewModel()
        {
            _studentCatalog = new StudentCatalog();
            _factory = new StudentViewModelFactory();
            _studentItemViewModelSelected = null;
            _deleteCommand = new DeleteCommand(_studentCatalog, this);
        }
        #endregion

        #region Properties for Data Binding
        public ICommand DeletionCommand
        {
            get { return _deleteCommand; }
        }

        public List<StudentItemViewModel> StudentItemViewModelCollection
        {
            get { return _factory.GetStudentItemViewModelCollection(_studentCatalog); }
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
        public void RefreshStudentItemViewModelCollection()
        {
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