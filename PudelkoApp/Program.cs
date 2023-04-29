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
            Pudelko p = new Pudelko(unit: UnitOfMeasure.milimeter, a: 100, b: 255, c: 3);
            Pudelko d = new Pudelko(unit: UnitOfMeasure.milimeter, a: 100.0, b: 25.58, c: 3.13);

            Console.WriteLine(p.A + " " + p.B + " " + p.C);
            Console.WriteLine("1.0 0.255 0.031");
            Console.WriteLine();
            Console.WriteLine(d.A + " " + d.B + " " + p.C);
            Console.WriteLine("1.0 0.255 0.031");
           // [DataRow(100, 255, 3, 0.1, 0.255, 0.003)]
           // [DataRow(100.0, 25.58, 3.13, 0.1, 0.025, 0.003)]
        }
    }
}
