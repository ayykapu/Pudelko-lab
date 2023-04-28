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

            var p = new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.meter);
            p.ToString(null);
            // Console.WriteLine(p.ToString("cm")); 
            //  Console.WriteLine(p.Objetosc);
        }
    }
}
