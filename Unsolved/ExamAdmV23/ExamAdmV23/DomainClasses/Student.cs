using ExamAdmV23.BaseClasses;

namespace ExamAdmV23.DomainClasses
{
    public class Student
    {
        private string _name;
        private int _yearOfBirth;
        private string _country;
        private string _imageSource;

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

        public string ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; }
        }

        public Student(string name, int yearOfBirth, string country, string imageSource)
        {
            _name = name;
            _yearOfBirth = yearOfBirth;
            _country = country;
            _imageSource = imageSource;
        }
    }
}