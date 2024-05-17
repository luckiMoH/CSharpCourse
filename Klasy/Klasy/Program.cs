namespace Klasy
{
    class Program
    {
        public static void Main(string[] args)
        {
            Person bill = new Person("Bill", "Wick");

            //bill.SetDateOfBirth(new DateTime(1990, 1, 1));
            bill.DateOfBirth = new DateTime(1990, 2, 2);
            bill.SayHi();
            bill.ContactNumber = "999888777";
            Console.WriteLine(bill.ContactNumber);
        }
    }
}