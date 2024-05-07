using System;

namespace FirstProject
{

    public class GradeCalculator
    {
        public static string CalculateGrade(double percentage)
        {
           if (percentage > 90)
           {
                return "A";
           }
           else if (percentage > 80 && percentage < 90) 
           {
                return "B";
           }
           else if (percentage > 70 && percentage < 80) 
           {
                return "C";
           }
           else if (percentage > 60 && percentage < 70)
           {
                return "D";
           }
           else 
           {
                return "F";
           }
        }
    }

    public class BMICalculator
    {
        public static string CalculatorBMI(double height, double weight)
        {
            double bmi = weight / (height * height)*10000;
            if (bmi < 18.5)
            {
                Console.WriteLine("Masz niedowagę");
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                Console.WriteLine("Twoja waga jest prawidłowa");
            }
            else if ( bmi >= 25 && bmi < 30)
            {
                Console.WriteLine("Masz nadwagę");
            }
            else if (bmi >= 30 && bmi < 35)
            {
                Console.WriteLine("Masz otyłość");
            }
            else
            {
                Console.WriteLine("Masz otyłość olbrzymią");
            }
                
         
            return bmi.ToString();
        }
    }

    public class ParkingCalculator
    {
        public static double CalculateParkingFee(int hours)
        {
            double result = 0;

            switch (hours)
            {
                case 1:
                    result = 5;
                    break;
                case > 1:
                    result = 5 + 3 * (hours - 1);
                    break;
            }

            return result;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            int randomNumber = new Random().Next(100);

            Console.WriteLine(randomNumber);

            string result = GradeCalculator.CalculateGrade(randomNumber);
            Console.WriteLine(result);

            int intResult = 0;

            switch (result)
            {
                case "A":
                    intResult = 6;
                    break;
                    case "B":
                    intResult = 5;
                    break;
                    case "C":
                    intResult = 4;
                    break;
                    case "D":
                    intResult = 3;
                    break;
                    case "F":
                    intResult = 1;
                    break;
                default:
                    break;
            }
            if (intResult != 0) // Sprawdź, czy zmienna intResult została zainicjowana
            {
                Console.WriteLine(intResult);
            }
            else
            {
                Console.WriteLine("Nieznany wynik"); // Możesz dodać obsługę dla nieznanej wartości
            }

            double fee = ParkingCalculator.CalculateParkingFee(2);

            Console.WriteLine(fee);

            Console.WriteLine("***********");

            Console.WriteLine("Ile masz wzrostu?");
            string heightString = Console.ReadLine();
            double height = double.Parse(heightString);
            Console.WriteLine("Ile ważysz?");
            string weightString = Console.ReadLine();
            double weight = double.Parse(weightString);

            string bmi = BMICalculator.CalculatorBMI(height, weight);
            Console.WriteLine("Kalkulator BMI");
             Console.WriteLine(bmi);
        }
    }
}