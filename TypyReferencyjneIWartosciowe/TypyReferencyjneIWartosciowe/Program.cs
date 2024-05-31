namespace TypyReferencyjneIWartosciowe
{
    class Program
    {

        static void Double(ref int value)
        {
            value = 2 * value;
            Console.WriteLine($"Doubled value: {value}");
        }

        static bool IsDivisible(int value, int factor, out int reminder)
        {
            reminder = value % factor;

            return reminder == 0;
        }

        static bool TryParseToNegativeInt(string input, out int result)
        {
            if(int.TryParse(input, out result))
            {
                if (result < 0)
                {
                    return true;
                } 
                else
                {
                    return false;
                }
            }
            else
            {
                result = default;
                return false;
            }
        }

        public static void Main(string[] args)
        {
            int someValue = 5;
            Double(ref someValue);

            Console.WriteLine($"some value: {someValue}");

            int value = 5;
            int factor = 2;
            int reminder;

            if(IsDivisible(value, factor, out reminder))
            {
                Console.WriteLine($"{value} is divisible by {factor}");
            }
            else
            {
                Console.WriteLine($"{value} is not divisible by {factor}. Reminder: {reminder}");
            }

            Console.WriteLine("");
            Console.WriteLine("**************");
            Console.WriteLine("");

            int inputValue;

            while(!TryParseToNegativeInt(Console.ReadLine(), out inputValue))
            {
                Console.WriteLine("Insert negative number");
            }

            Console.WriteLine($"Inserted negative number is {inputValue}");

        }

    }
}