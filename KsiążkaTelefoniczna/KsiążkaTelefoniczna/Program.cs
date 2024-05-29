namespace PhoneBook
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello from the PhoneBook app");

            Console.WriteLine("1 Add contact");
            Console.WriteLine("2 Display contact by number");
            Console.WriteLine("3 Display all contacts");
            Console.WriteLine("4 Search contacts");
            Console.WriteLine("5 remove contact");
            Console.WriteLine("To exit insert 'x'");

            string userInput = Console.ReadLine();

            var phoneBook = new PhoneBook();

            while (true)
            {
                switch (userInput)
                {
                    case "1":

                        Console.WriteLine("Insert number");
                        var number = Console.ReadLine();

                        if (number.Length < 9)
                        {
                            Console.WriteLine("Number should be 9 characters long");
                            break;
                        }

                        Console.WriteLine("Insert name");
                        var name = Console.ReadLine();

                        if (name.Length < 3)
                        {
                            Console.WriteLine("Name should be at least 3 characters long");
                            break;
                        }

                        var newContact = new Contact(name, number);

                        phoneBook.AddContact(newContact);

                        break;
                    case "2":

                        Console.WriteLine("Insert number");
                        var numberToSearch = Console.ReadLine();

                        phoneBook.DisplayContact(numberToSearch);

                        break;
                    case "3":

                        phoneBook.DisplayAllContacts();

                        break;
                    case "4":

                        Console.WriteLine("Insert number");
                        var nameSearched = Console.ReadLine();

                        phoneBook.DisplayMatchingContacts(nameSearched);

                        break;
                    case "5":

                        Console.WriteLine("Insert number");
                        var numberToRemove = Console.ReadLine();

                        phoneBook.RemoveContact(numberToRemove);
                        break;

                    case "x":
                        return;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
                Console.WriteLine("Select operation");
                userInput = Console.ReadLine();
            }


        }
    }
}