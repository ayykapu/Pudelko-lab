using PudelkoLib;
using System;
using System.Globalization;

namespace PudelkoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pudelko p = new Pudelko(100.0, 100.0, 100.0, UnitOfMeasureType.milimeters);

            Console.WriteLine(p.ToString("m", CultureInfo.InvariantCulture));
        }
    }
}
