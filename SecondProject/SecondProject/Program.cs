
namespace SecondProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj dzień swoich urodzin");
            int dayOfBirth = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj miesiąc swoich urodzin");
            int monthOfBirth = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj rok swoich urodzin");
            int yearOfBirth = int.Parse(Console.ReadLine());

            DateTime todayDate = DateTime.Now;
            DateTime dateOfBirth = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);

            TimeSpan difference = todayDate - dateOfBirth;

            int differenceDays = difference.Days;
            Console.WriteLine(differenceDays);
            Console.WriteLine(difference.TotalDays);
        }
    }
}