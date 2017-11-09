using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamAdmV22
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
        public string Name
        {
            get { return _domainObject.Name; }
        }

        public string ImageSource
        {
            get { return _domainObject.ImageSource; }
        }

        public string CountryStr
        {
            get { return "From " + _domainObject.Country; }
        }

        public string BirthStr
        {
            get { return "(Born " + _domainObject.YearOfBirth + ")"; }
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