using System.Threading.Tasks;
using System.Linq;
using FirstProject;

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
                if (employee.DateOfBirth > new DateTime(2000, 1, 1))
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
            }
            else
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

            Console.WriteLine("LAMBDA");

            List<Person> youngEmployeesLambda = employees.Where(e => e.DateOfBirth > new DateTime(2000, 1, 1)).ToList();
            Person dollieLambda = youngEmployees.FirstOrDefault(e => e.FirstName == "Dollie");

            if (dollieLambda != null)
            {
                dollieLambda.SayHi();
            }
            else
            {
                Console.WriteLine("Dollie not found");
            }

            Console.WriteLine("Słownik - Dictionary - przed refactorem");

            static List<Currency> GetCurrencies()
            {
                return new List<Currency>
                {
                    new Currency("usd", "United States, Dollar", 1),
                    new Currency("eur", "Euro", 0.83975),
                    new Currency("gbp", "British Pound", 0.74771),
                    new Currency("cad", "Canadian Dollar", 1.30724),
                    new Currency("inr", "Indian Rupee", 73.04),
                    new Currency("mxn", "Mexican Peso", 21.7571)
                };
            }

            List<Currency> currencies = GetCurrencies();
            Console.WriteLine("Check the rate for:");
            string userInput = Console.ReadLine();

            Currency selectedCurrency = currencies.FirstOrDefault(c => c.Name == userInput);
            if (selectedCurrency != null)
            {
                Console.WriteLine($"Rate for USD to {selectedCurrency.FullName} is {selectedCurrency.Rate}");
            }
            else
            {
                Console.WriteLine("Currency not found");
            }

            Console.WriteLine("Słownik - Dictionary - po refactorze");

            static Dictionary<string, Currency> GetCurrenciesDictionary()
            {
                return new Dictionary<string, Currency>
                {
                    {"usd", new Currency("usd", "United States, Dollar", 1) },
                    { "eur", new Currency("eur", "Euro", 0.83975) },
                    { "gbp", new Currency("gbp", "British Pound", 0.74771) },
                    { "cad", new Currency("cad", "Canadian Dollar", 1.30724) },
                    { "inr", new Currency("inr", "Indian Rupee", 73.04) },
                    { "mxn", new Currency("mxn", "Mexican Peso", 21.7571) }
                };
            }

            Dictionary<string, Currency> currenciesDictionary = GetCurrenciesDictionary();

            //Usuwanie elementów w słowniku

            currenciesDictionary.Remove("usd");

            //dodawanie elementów do słownika

            currenciesDictionary.TryAdd("pln", new Currency("pln", "Polski Złoty", 0.25));

            Console.WriteLine("Check the rate for:");
            string userInputDictionary = Console.ReadLine();

            Currency selectedCurrencyDictionary = null;
            if (currenciesDictionary.TryGetValue(userInputDictionary, out selectedCurrencyDictionary))
            {
                Console.WriteLine($"Rate for USD to {selectedCurrencyDictionary.FullName} is {selectedCurrencyDictionary.Rate}");
            }
            else
            {
                Console.WriteLine("Currency not found");
            }

            //Usuwanie elementów w słowniku

            currenciesDictionary.Remove("usd");

            //dodawanie elementów do słownika

            currenciesDictionary.TryAdd("pln", new Currency("pln", "Polski Złoty", 0.25));

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