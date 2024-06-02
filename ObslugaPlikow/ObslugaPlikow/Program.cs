namespace ObslugaPlikow
{
    class Program
    {
        static void ReadFiles()
        {
            var document1 = File.ReadAllText(@"D:\TextFiles\Read\document1.txt");
            var document2 = File.ReadAllLines(@"D:\TextFiles\Read\document2.txt");

            var document2String = string.Join(Environment.NewLine, document2);

            Console.WriteLine("document1");
            Console.WriteLine(document1);
            Console.WriteLine("document2");
            Console.WriteLine(document2String);
        }

        static void GenerateDocuments()
        {
            Console.WriteLine("Insert name:");
            var name = Console.ReadLine();

            Console.WriteLine("Insert order number:");
            var orderNumber = Console.ReadLine();

            var template = File.ReadAllText(@"D:/TextFiles/Write/template.txt");
            var document = template.Replace("{name}", name)
                .Replace("{orderNumber}", orderNumber)
                .Replace("{dateTime}", DateTime.Now.ToString());

            File.WriteAllText($"D:/TextFiles/Write/document-{orderNumber}.txt", document);
        }

        static void ScanAndAppend()
        {
            var files = Directory.GetFiles("D:/TextFiles/Append/", "*.txt", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                File.AppendAllText(file, "\nAll rights reserved");
            }
        }

        public static void Main(string[] args)
        {
            //ReadFiles();
            //GenerateDocuments();
            ScanAndAppend();
           
        }
    }
}