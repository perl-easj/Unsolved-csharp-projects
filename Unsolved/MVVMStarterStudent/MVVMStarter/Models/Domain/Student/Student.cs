using MVVMStarter.Configuration.App;
using MVVMStarter.Models.Base;

namespace MVVMStarter.Models.Domain.Student
{
    public class Student : DomainClassBase
    {
        private string _name;
        private int _yearOfBirth;
        private string _country;
        private int _zipCode;
        private string _city;
        private string _photoID;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int YearOfBirth
        {
            get { return _yearOfBirth; }
            set { _yearOfBirth = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public int ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string PhotoID
        {
            get { return _photoID; }
            set { _photoID = value; }
        }

        public string ImageSource
        {
            get { return AppConfig.ImageFilePrefix + "Student\\" + PhotoID + AppConfig.ImageFilePostfix; }
        }

        public override void SetDefaultValues()
        {
            _name = "(Name)";
            _yearOfBirth = 2000;
            _country = "(Country)";
            _zipCode = 1234; ;
            _city = "(City)";
            _photoID = "Student";
        }
    }
}

