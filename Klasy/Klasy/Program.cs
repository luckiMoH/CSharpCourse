﻿namespace Klasy
{
    class Program
    {
        public static void Main(string[] args)
        {
            Person bill = new Person();

            bill.FirstName = "Bill";
            bill.SetDateOfBirth(new DateTime(1990, 1, 1));

            bill.SayHi();
        }
    }
}