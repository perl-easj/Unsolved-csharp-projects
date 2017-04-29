using System.Collections.Generic;

namespace ExamAdmV22
{
    public class StudentMasterViewModel
    {
        public List<StudentItemViewModel> GetStudentItemViewModelCollection(StudentCollection collection)
        {
            List<StudentItemViewModel> items = new List<StudentItemViewModel>();

            foreach (Student s in collection.Students)
            {
                items.Add(new StudentItemViewModel(s));
            }

            return items;
        }
    }
}
