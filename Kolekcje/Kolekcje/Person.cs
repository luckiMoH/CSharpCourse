using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolekcje
{
    internal class Person
    {
        public string FirstName;
        public string LastName;

        //private DateTime dateOfBirth;

        public DateTime DateOfBirth { get; set; }

        public static int Count = 0;

        private string contactNumber;

        public string ContactNumber
        {
            get { return contactNumber; }
            set 
            { 
                if (value.Length < 9 )
                {
                    Console.WriteLine("Invalid contact number");
                } 
                else
                {
                contactNumber = value; 
                }
            }
        }

        //public string ContactNumber {  get; set; }

        //Konstruktor Person
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Count++;
        }

        //Rozszerzenie konstruktora
        public Person(DateTime dateOfBirth, string firstName, string lastName) : this(firstName, lastName)
        {
            DateOfBirth = dateOfBirth;
        }

        //public void SetDateOfBirth(DateTime date)
        //{
        //    if(date > DateTime.Now)
        //    {
        //        Console.WriteLine("Invalid date of birth");
        //    } 
        //    else
        //    {
        //        dateOfBirth = date;
        //    }
        //}

        //public DateTime GetDateOfBirth()
        //{
        //    return dateOfBirth;
        //}

        public void SayHi()
        {
            Console.WriteLine($"Hi, I'm {FirstName} {LastName}, {DateOfBirth}");
        }
    }
}
