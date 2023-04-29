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
            Pudelko p = new Pudelko(unit: UnitOfMeasure.milimeter, a: 1, b: 0.1);
            Console.WriteLine(p);

        }
    }
}
