using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExamAdmV22
{
    public class StudentMasterDetailsViewModel : INotifyPropertyChanged
    {
        private StudentCollection _studentCollection;
        private StudentItemViewModel _studentItemViewModelSelected;
        private StudentMasterViewModel _studentMasterViewModel;
        private RelayCommand _deleteCommand;

        public StudentMasterDetailsViewModel()
        {
            _studentCollection = new StudentCollection();
            _studentMasterViewModel = new StudentMasterViewModel();
            _deleteCommand = null; // This needs to be changed
            _studentItemViewModelSelected = null;
        }

        public List<StudentItemViewModel> StudentItemViewModelCollection
        {
            get { return _studentMasterViewModel.GetStudentItemViewModelCollection(_studentCollection); }
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

        public void Delete(string name)
        {
            // Delete from model collection
            _studentCollection.Delete(name);

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