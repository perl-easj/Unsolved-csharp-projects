using ExamAdmV23.BaseClasses;
using System.Collections.Generic;

namespace ExamAdmV23.DomainClasses
{
    public class StudentMasterViewModel
    {
        public List<StudentItemViewModel> GetStudentItemViewModelCollection(StudentModel model)
        {
            List<StudentItemViewModel> items = new List<StudentItemViewModel>();

            foreach (Student s in model.Students)
            {
                items.Add(new StudentItemViewModel(s));
            }

            return items;
        }
    }
}
