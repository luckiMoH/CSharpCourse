using System.Threading.Tasks;

namespace Kolekcje
{
    class Program
    {
        public static void Main(string[] args)
        {

            static void DisplayElements(List<int> list)
            {
                Console.WriteLine("** List **");
                foreach (int i in list)
                {
                    Console.Write($"{i}, ");
                }

                Console.WriteLine();
            }

            int[] intArray = { 1, 2, 3, 4, 5 };
            int arrayLenght = intArray.Length;

            List<int> intList = new List<int>() { 6, 1, 20, 3, 45, 60, 100, 2 };
            DisplayElements(intList);

            Console.WriteLine("New Element: ");
            string userInput = Console.ReadLine();
            int intValue = int.Parse(userInput);

            intList.Add(intValue);

            DisplayElements(intList);

            Console.WriteLine("** Remove Range **");
            intList.RemoveRange(1, 2);
            DisplayElements(intList);

            Console.WriteLine("Sort");
            intList.Sort();
            DisplayElements(intList);
            
        }
    }
}