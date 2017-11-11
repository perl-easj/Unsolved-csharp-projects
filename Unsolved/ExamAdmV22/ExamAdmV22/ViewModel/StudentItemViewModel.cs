using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExamAdmV22.Model;

namespace ExamAdmV22.ViewModel
{
    public class StudentItemViewModel : INotifyPropertyChanged
    {
        private Student _domainObject;

        #region Constructor
        public StudentItemViewModel(Student s)
        {
            _domainObject = s;
        }
        #endregion

        #region Properties for Data Binding
        public Student DomainObject
        {
            get { return _domainObject; }
        }

        public string ImageSource
        {
            get { return _domainObject.ImageSource; }
        }

        public string Description
        {
            get { return _domainObject.Name; }
        }
        #endregion

        #region Code for OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}