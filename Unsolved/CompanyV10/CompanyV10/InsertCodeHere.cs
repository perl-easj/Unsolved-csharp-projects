using System;
using System.Collections.Generic;

namespace CompanyV10
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            List<Employee> company = new List<Employee>();
            // Add some employees to the list

            foreach (Employee e in company)
            {
                Console.WriteLine("{0} receives a salary of {1} kr.",e.Name, e.SalaryPerMonth);
            }

            // The LAST line of code should be ABOVE this line
        }
    }
}