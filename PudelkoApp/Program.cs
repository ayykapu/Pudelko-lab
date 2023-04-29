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
            Pudelko p = new Pudelko(2,3,4,UnitOfMeasure.meter);
            Console.WriteLine(p.Pole);
        }
    }
}
