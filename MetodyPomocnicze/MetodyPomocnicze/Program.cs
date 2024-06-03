namespace MetodyPomocnicze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert input:");
            string userInput = Console.ReadLine();


            string reversed = new string(userInput.Reverse().ToArray());
            Console.WriteLine(reversed);

            //SubString(userInput);
            //Replace(userInput);
            //Modify(userInput);
            //AlterTextCase(userInput);
            //Split(userInput);
            CheckString(userInput);
        }

        static void SubString(string userInput)
        {
            if (userInput.Length > 10)
            {
                string startSubstring = userInput.Substring(0, 10);
                string endSubstring = userInput.Substring(userInput.Length - 10);
                Console.WriteLine($"{startSubstring}..., ...{endSubstring}");
                Console.WriteLine(userInput);
            }
        }

        static void Replace(string userInput)
        {
            string template = "Hello {name}, how are you?";
            string output = template.Replace("{name}", userInput);
            Console.WriteLine(output);
        }

        static void Modify(string userInput)
        {
            string removedString = userInput.Remove(5);
            Console.WriteLine(removedString);
            string insertedString = userInput.Insert(5, "INSERT");
            Console.WriteLine(insertedString);
            string trimmedString = userInput.Trim();
            Console.WriteLine(trimmedString);
        }

        static void AlterTextCase(string userInput)
        {
            string upperCased = userInput.ToUpper();
            string lowerCased = userInput.ToLower();
            Console.WriteLine(upperCased);
            Console.WriteLine(lowerCased);
        }

        static void Split(string userInput)
        {
            string[] inputParts = userInput.Split(" ");
            string firstName = inputParts[0];
            string lastName = inputParts[inputParts.Length - 1];
            Console.WriteLine($"Hello {firstName} {lastName}");
        }

        static void CheckString(string userInput)
        {
            bool isTextFile = userInput.EndsWith(".txt");
            bool startsWithDocPrefix = userInput.StartsWith("doc-");

            Console.WriteLine($"isTextFile: {isTextFile}", StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine($"startsWithDocPrefix: {startsWithDocPrefix}", StringComparison.CurrentCultureIgnoreCase);

            bool isMateusz = userInput.Contains("Mateusz", StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine($"IsMateusz: {isMateusz}");

        }
    }
}