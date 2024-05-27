using System.Threading.Tasks;
using System.Linq;

namespace Kolekcje
{
    class Program
    { 
        public static void Main(string[] args)
        {

            static List<Person> GetEmployees()
            {
                List<Person> employees = new List<Person>()
                {
                    new Person(new DateTime(1990, 2, 2), "Bill", "Wick"),
                    new Person(new DateTime(1995, 3, 4), "John", "Wick"),
                    new Person(new DateTime(1996, 4, 2), "Ollie", "Wick"),
                    new Person(new DateTime(2001, 5, 3), "Dollie", "Wick"),
                    new Person(new DateTime(2000, 6, 2), "Martha", "Wick"),
                    new Person(new DateTime(2005, 7, 1), "Bob", "Wick"),
                    new Person(new DateTime(2003, 7, 1), "Ed", "Wick")
                };
                return employees;
            }

            Console.WriteLine("Pracownicy:");
            List<Person> employees = GetEmployees();
            List<Person> youngEmployees = new List<Person>();

            foreach (Person employee in employees)
            {
                if(employee.DateOfBirth > new DateTime(2000,1,1))
                {
                    youngEmployees.Add(employee);
                }
            }

            Console.WriteLine("Young employees: " + youngEmployees.Count);

            Person bob = null;
            foreach (Person youngEmployee in youngEmployees)
            {
                if (youngEmployee.FirstName == "Bob")
                {
                    bob = youngEmployee;
                    break;
                }
            }
            if (bob != null)
            {
                bob.SayHi();
            } else
            {
                Console.WriteLine("Bob not found");
            }

            Console.WriteLine("LINQ");

            bool EmployeeIsYoung(Person employee)
            {
                return employee.DateOfBirth > new DateTime(2000, 1, 1);
            }
            List<Person> youngEmployeesLINQ = employees.Where(EmployeeIsYoung).ToList();

            bool EmployeeIsEd(Person employee)
            {
                return employee.FirstName == "Ed";
            }
            Person edLINQ = youngEmployees.FirstOrDefault(EmployeeIsEd);

            if (edLINQ != null)
            {
                edLINQ.SayHi();
            }
            else
            {
                Console.WriteLine("Ed not found");
            }




            Console.WriteLine("************");

            //static void DisplayElements(List<int> list)
            //{
            //    Console.WriteLine("** List **");
            //    foreach (int i in list)
            //    {
            //        Console.Write($"{i}, ");
            //    }

            //    Console.WriteLine();
            //}

            //int[] intArray = { 1, 2, 3, 4, 5 };
            //int arrayLenght = intArray.Length;

            //List<int> intList = new List<int>() { 6, 1, 20, 3, 45, 60, 100, 2 };
            //DisplayElements(intList);

            //Console.WriteLine("New Element: ");
            //string userInput = Console.ReadLine();
            //int intValue = int.Parse(userInput);

            //intList.Add(intValue);

            //DisplayElements(intList);

            //Console.WriteLine("** Remove Range **");
            //intList.RemoveRange(1, 2);
            //DisplayElements(intList);

            //Console.WriteLine("Sort");
            //intList.Sort();
            //DisplayElements(intList);
            
        }
    }
}