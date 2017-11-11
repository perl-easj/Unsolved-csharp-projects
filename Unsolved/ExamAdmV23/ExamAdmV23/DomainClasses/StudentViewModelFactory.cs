using System.Collections.Generic;

namespace ExamAdmV23.DomainClasses
{
    public class StudentViewModelFactory
    {
        public StudentItemViewModel CreateItemViewModel(Student obj)
        {
            return new StudentItemViewModel(obj);
        }

        public List<StudentItemViewModel> GetStudentItemViewModelCollection(StudentCatalog catalog)
        {
            List<StudentItemViewModel> items = new List<StudentItemViewModel>();

            foreach (Student s in catalog.Students)
            {
                items.Add(new StudentItemViewModel(s));
            }

            return items;
        }
    }
}