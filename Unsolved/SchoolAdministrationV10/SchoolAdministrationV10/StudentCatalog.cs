using System.Collections.Generic;
using System.Linq;

namespace SchoolAdministrationV10
{
    public class StudentCatalog
    {
        private Dictionary<int, Student> _students;

        public StudentCatalog()
        {
            _students = new Dictionary<int, Student>();
        }

        /// <summary>
        /// Return the number of students in the catalog.
        /// </summary>
        public int Count
        {
            // The below must be changed
            get { return 0; }
        }

        /// <summary>
        /// Add a single student to the catalog.
        /// </summary>
        public void AddStudent(Student aStudent)
        {
            // Add code here
        }

        /// <summary>
        /// Given an id, return the student with that id.
        /// If no student exists with the given id, return null.
        /// </summary>
        public Student GetStudent(int id)
        {
            // The below must be changed
            return null;
        }

        /// <summary>
        /// Given an id, return the score average for the student with that id.
        /// If no student exists with the given id, return -1.
        /// </summary>
        public int GetAverageForStudent(int id)
        {
            // The below must be changed
            return -1;
        }

        /// <summary>
        /// Returns the total test score average for ALL students in the catalog.
        /// </summary>
        public int GetTotalAverage()
        {
            // The below must be changed
            return -1;
        }
    }
}