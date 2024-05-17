using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    internal class Person
    {
        public string FirstName;
        public string LastName;

        private DateTime dateOfBirth;

        //Konstruktor Person
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        //Rozszerzenie konstruktora
        public Person(DateTime dateOfBirth, string firstName, string lastName) : this(firstName, lastName)
        {
            SetDateOfBirth(dateOfBirth);
        }

        public void SetDateOfBirth(DateTime date)
        {
            if(date > DateTime.Now)
            {
                Console.WriteLine("Invalid date of birth");
            } 
            else
            {
                dateOfBirth = date;
            }
        }

        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }

        public void SayHi()
        {
            Console.WriteLine($"Hi, I'm {FirstName} {LastName}, {GetDateOfBirth()}");
        }
    }
}
