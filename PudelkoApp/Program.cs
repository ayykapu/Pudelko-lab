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


            Pudelko p = new Pudelko(a: 0.1, b: 1, unit: UnitOfMeasure.milimeter);
            Console.WriteLine(p);
            // [DataRow(100, 255, 3, 0.1, 0.255, 0.003)]
            // [DataRow(100.0, 25.58, 3.13, 0.1, 0.025, 0.003)]
        }
    }
}
