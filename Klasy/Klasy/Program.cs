using ClassLibrary;

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

            Person john = new Person(new DateTime(2000, 10, 15), "John", "Wick");

            john.SayHi();

            Console.WriteLine(Person.Count);

            Console.WriteLine("");
            Console.WriteLine("---Dziedziczenie---");
            Console.WriteLine("");

            ExcelFile excelFile = new ExcelFile();

            excelFile.CreatedOn = DateTime.Now;
            excelFile.FileName = "excel-file";

            excelFile.GenerateReport();

            WordDocumentFile wordDocumentFile = new WordDocumentFile();

            wordDocumentFile.CreatedOn = DateTime.Now;
            wordDocumentFile.FileName = "word-file";

            wordDocumentFile.Print();

            Console.WriteLine("");
            Console.WriteLine("---Polimorfizm---");
            Console.WriteLine("");

            Shape[] shapes = { new Circle(), new Rectangle(), new Triangle() };

            foreach(Shape shape in shapes)
            {
                shape.Draw();
            }

        }
    }
}