using PudelkoLib;
using System;
using System.Globalization;

namespace PudelkoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pudelko p = new Pudelko(2.5, 9.321, 0.1, UnitOfMeasureType.meter);

            // Console.WriteLine(p.ToString("cm")); 
            Console.WriteLine(p.Objetosc);
        }
    }
}
