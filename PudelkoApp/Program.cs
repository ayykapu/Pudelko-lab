using PudelkoLib;
using System;

namespace PudelkoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pudelko p = new Pudelko(1.0, 2.0, 3.0, UnitOfMeasureType.milimeters);
            Console.WriteLine(p);

            
            p.ToString();
        }
    }
}
