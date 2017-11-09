using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamAdmV22
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
            _studentItemViewModelSelected = null;

            _deleteCommand = null; // TODO - This needs to be changed
        }
        #endregion

        #region Properties for Data Binding
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
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        public void Delete(string name)
        {
            // Delete from model collection
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