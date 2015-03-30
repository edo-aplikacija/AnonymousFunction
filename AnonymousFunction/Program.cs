using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID = 1, Name = "Mary" });
            empList.Add(new Employee() { ID = 2, Name = "John" });

            // Step Two
            Predicate<Employee> predicateEmp = new Predicate<Employee>(FindEmployee);
            // Step Three
            Employee employee = empList.Find(e => predicateEmp(e));

            // Anonymous function replace step one, two and three
            Employee emp = empList.Find(delegate (Employee e) {
                return e.ID == 1;
            });
            Console.WriteLine("Regular: Employee name is " + employee.Name);
            Console.WriteLine("Anonymous Function: Employee name is " + emp.Name);
            Console.ReadLine();
        }

        // Step One
        public static bool FindEmployee(Employee emp)
        {
            if (emp.ID == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    

    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
