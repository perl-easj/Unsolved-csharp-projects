using System;

namespace SchoolAdministrationV10
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            StudentCatalog students = new StudentCatalog();

            Student anna = new Student(12, "Anna");
            Student betty = new Student(338, "Betty");
            Student carl = new Student(92, "Carl");

            anna.AddTestResult("English", 85);
            anna.AddTestResult("Math", 70);
            anna.AddTestResult("Biology", 90);
            anna.AddTestResult("French", 52);

            betty.AddTestResult("English", 77);
            betty.AddTestResult("Math", 82);
            betty.AddTestResult("Chemistry", 65);
            betty.AddTestResult("French", 41);

            carl.AddTestResult("English", 55);
            carl.AddTestResult("Math", 48);
            carl.AddTestResult("Biology", 70);
            carl.AddTestResult("French", 38);

            students.AddStudent(anna);
            students.AddStudent(betty);
            students.AddStudent(carl);

            // Does the output match what you expect...?
            Console.WriteLine(students.Count);
            Console.WriteLine(students.GetStudent(12) == null ? "Student with id 12 not found" : students.GetStudent(12).Name);
            Console.WriteLine(students.GetStudent(456) == null ? "Student with id 456 not found" : students.GetStudent(456).Name);
            Console.WriteLine(students.GetStudent(338) == null ? "Student with id 338 not found" : students.GetStudent(338).Name);
            Console.WriteLine(students.GetStudent(92) == null ? "Student with id 92 not found" : students.GetStudent(92).Name);
            Console.WriteLine(students.GetAverageForStudent(12));
            Console.WriteLine(students.GetAverageForStudent(338));
            Console.WriteLine(students.GetAverageForStudent(92));
            Console.WriteLine(students.GetAverageForStudent(120));
            Console.WriteLine(students.GetTotalAverage());


            // The LAST line of code should be ABOVE this line
        }
    }
}