using System.Collections.Generic;

namespace ExamAdmV22
{
    public class StudentMasterViewModel
    {
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
