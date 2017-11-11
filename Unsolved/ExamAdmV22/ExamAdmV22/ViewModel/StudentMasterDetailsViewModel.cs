using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExamAdmV22.Model;

namespace ExamAdmV22.ViewModel
{
    public class StudentMasterDetailsViewModel : INotifyPropertyChanged
    {
        #region Instance fields
        private StudentCatalog _studentCatalog;
        private StudentItemViewModel _studentItemViewModelSelected;
        private StudentDetailsViewModel _studentDetailsViewModel;
        private DeleteCommand _deleteCommand;
        #endregion

        #region Constructor
        public StudentMasterDetailsViewModel()
        {
            _studentCatalog = new StudentCatalog();
            _studentItemViewModelSelected = null;
            _studentDetailsViewModel = null;

            _deleteCommand = null; // TODO - This needs to be changed
        }
        #endregion

        #region Properties for Data Binding
        public List<StudentItemViewModel> StudentItemViewModelCollection
        {
            get { return GetStudentItemViewModelCollection(); }
        }

        public StudentItemViewModel StudentItemViewModelSelected
        {
            get { return _studentItemViewModelSelected; }
            set
            {
                _studentItemViewModelSelected = value;
                _studentDetailsViewModel = _studentItemViewModelSelected == null ? null 
                    : new StudentDetailsViewModel(_studentItemViewModelSelected.DomainObject);
                OnPropertyChanged();
                OnPropertyChanged(nameof(StudentDetailsViewModel));
            }
        }

        public StudentDetailsViewModel StudentDetailsViewModel
        {
            get { return _studentDetailsViewModel; }
            set
            {
                _studentDetailsViewModel = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        public void RefreshStudentItemViewModelCollection()
        {
            OnPropertyChanged(nameof(StudentItemViewModelCollection));
        }

        private List<StudentItemViewModel> GetStudentItemViewModelCollection()
        {
            List<StudentItemViewModel> items = new List<StudentItemViewModel>();

            foreach (Student s in _studentCatalog.Students)
            {
                items.Add(new StudentItemViewModel(s));
            }

            return items;
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