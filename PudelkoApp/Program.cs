using PudelkoLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PudelkoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pudelko p1 = new Pudelko(0.3, 0.5, 0.4, UnitOfMeasure.meter);
            Pudelko p2 = new Pudelko(30, 50, 40, UnitOfMeasure.centimeter);
            Pudelko p3 = new Pudelko(300, 50, 400, UnitOfMeasure.milimeter);

            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p3.Equals(p1));
            Console.WriteLine(p2.Equals(p3));

        }
    }
}
