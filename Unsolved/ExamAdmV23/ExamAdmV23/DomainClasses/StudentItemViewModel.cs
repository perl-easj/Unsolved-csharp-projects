using ExamAdmV23.BaseClasses;

namespace ExamAdmV23.DomainClasses
{
    public class StudentItemViewModel
    {
        private Student _domainObject;

        #region Constructor
        public StudentItemViewModel(Student obj)
        {
            _domainObject = obj;
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
    }
}
