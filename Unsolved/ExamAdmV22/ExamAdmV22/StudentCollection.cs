using System.Collections.Generic;
using System.Linq;

namespace ExamAdmV22
{
    public class StudentCollection
    {
        private Dictionary<string, Student> _students;

        public StudentCollection()
        {
            _students = new Dictionary<string, Student>();

            _students.Add("Ann", new Student("Ann", 1988, "Canada", "Assets\\ann.jpg"));
            _students.Add("Benny", new Student("Benny", 1982, "England", "Assets\\benny.jpg"));
            _students.Add("Carol", new Student("Carol", 1993, "USA", "Assets\\carol.jpg"));
            _students.Add("Daniel", new Student("Daniel", 1990, "Denmark", "Assets\\daniel.jpg"));
            _students.Add("Eliza", new Student("Eliza", 1974, "Australia", "Assets\\eliza.jpg"));
        }

        public List<Student> Students
        {
            get { return _students.Values.ToList(); }
        }

        public void Delete(string name)
        {
            _students.Remove(name);
        }
    }
}