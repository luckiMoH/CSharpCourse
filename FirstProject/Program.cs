using System;
using System.Linq;

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

            Console.WriteLine("--------Tablice");
            string[] cars = { "Volvo", "BMW", "Skoda", "Audi" };
            Console.WriteLine(cars[1]);
            int arrayLength = cars.Length;
            Console.WriteLine(arrayLength);

            Console.WriteLine("----Pętla while----");
            int i = 0;
            while (i < arrayLength)
            {
                Console.WriteLine(cars[i]);
                i++;
            }
            Console.WriteLine("----Pętla do while----");

            Console.WriteLine("to exic, type 'x'");
            string userInput;
            do
            {
                userInput = Console.ReadLine();
                Console.WriteLine($"Echo : {userInput}");
            } while (userInput != "x");

            Console.WriteLine("----Pętla for----");

            for (int y = 0; y < arrayLength; y++)
            {
                Console.WriteLine(cars[y]);
            }

            Console.WriteLine("----Pętla foreach----");

            foreach (string car in cars)
            {
                Console.WriteLine(car);
                if (car == "Skoda")
                {
                    Console.WriteLine($"{car} jest fajną marką");
                    break;
                }
            }

            Console.WriteLine("----ćwiczenie----");


            int[] temp = { 7, 11, 5, 16, 8 };
            int highest = temp[0];
            int lowest = temp[0];

            for (i = 0; i < temp.Length; i++)
            {
                if (temp[i] > highest)
                {
                    highest = temp[i];
                }
            }
            Console.WriteLine("highest" + highest);

            foreach (int te in temp)
            {
                if (te < lowest)
                {
                    lowest = te;
                    break;
                }
            }
            Console.WriteLine("lowest" + lowest);

            Console.WriteLine("----ENUMS----");
            Console.WriteLine("What is your gender? 1 - Male, 2 - Female");
            string userInputGender = Console.ReadLine();
            Gender userGender = (Gender)Enum.Parse(typeof(Gender), userInputGender);

            if (userGender == Gender.Male)
            {
                Console.WriteLine("Only women are allowed");

            } else
            {
                Console.WriteLine("Hi");
            }
        }
    }
}