using PudelkoLib;
using PudelkoApp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace PudelkoApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
           
            List<Pudelko> x = new List<Pudelko>
            {
                new Pudelko(),
                new Pudelko(1, 3),
                new Pudelko(1,3.3,4.1, UnitOfMeasure.meter),
                new Pudelko(100, 40, 600, UnitOfMeasure.centimeter),
                new Pudelko(2, 4, 6, UnitOfMeasure.meter),
            };
            Console.WriteLine("List: ");
            foreach (Pudelko p5 in x)
            {
                Console.WriteLine(p5);
            }

            x.Sort(Order);

            Console.WriteLine();
            Console.WriteLine("List in order: ");
            foreach (Pudelko p5 in x)
            {
                Console.WriteLine(p5);
            }
            Console.WriteLine();
            Console.WriteLine("=============================================================");
            Console.WriteLine();

            Pudelko final = new Pudelko(2.5, 4, 3.2, UnitOfMeasure.meter);
            Console.WriteLine("To.String: ");
            Console.WriteLine(final.ToString());
            Console.WriteLine(final.ToString("m"));
            Console.WriteLine(final.ToString("cm"));
            Console.WriteLine(final.ToString("mm"));
            Console.WriteLine();
            Console.WriteLine("Properties: ");
            Console.WriteLine(final.A);
            Console.WriteLine(final.B);
            Console.WriteLine(final.C);
            Console.WriteLine(final.Objetosc);
            Console.WriteLine(final.Pole) ;
            Console.WriteLine();
            Console.WriteLine("Equals: ");
            Pudelko final2 = new Pudelko(2.5, 4, 3.2, UnitOfMeasure.meter);
            Console.WriteLine(final.Equals(final2));
            Console.WriteLine();
            Console.WriteLine("GetHashCode: ");
            Console.WriteLine(final.GetHashCode());
            Console.WriteLine();
            Console.WriteLine(" ==, !=: ");
            Console.WriteLine(final == final2);
            Console.WriteLine(final != final2);
            Console.WriteLine();
            Console.WriteLine("+: ");
            Console.WriteLine(final + final2);
            Console.WriteLine();
            Console.WriteLine("Pudelko -> double: ");
            double[] array = ((double[])final);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.WriteLine();
            Console.WriteLine("ValueTuple -> Pudelko: ");
            Pudelko final3 = new Pudelko(2,4,5);
            Console.WriteLine(final3);
            Console.WriteLine();
            Console.WriteLine("Indexer: ");
            for (int i = 0;i < 3 ;i++) 
            {
                Console.WriteLine(final[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Foreach: ");
            foreach (double edge in final)
            {
                Console.WriteLine(edge);
            }
            Console.WriteLine();
            Console.WriteLine("Parse: ");
            Pudelko final4 = Pudelko.Parse("2.500 m × 9.321 m × 0.100 m");
            Console.WriteLine(final4);
            Console.WriteLine();
            Console.WriteLine("Extention Kompresuj(): ");
            Pudelko final5 = ExtensionMethods.Kompresuj(final);
            Console.WriteLine(final5);
        }

        private static int Order(Pudelko p1, Pudelko p2)
        {
            int result = p1.Objetosc.CompareTo(p2.Objetosc);

            if (result == 0)
            {
                result = p1.Pole.CompareTo(p2.Pole);

                if (result == 0)
                {
                    double p1Sum = p1.A + p1.B + p1.C;
                    double p2Sum = p2.A + p2.B + p2.C;
                    result = p1Sum.CompareTo(p2Sum);
                }
            }

            return result;
        }
    }
}
    

