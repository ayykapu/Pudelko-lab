﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Enumeration;
using System.Runtime.InteropServices;

namespace PudelkoLib
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
        private readonly UnitOfMeasure unit;

        public double A
        { get { return a; } }
        public double B
        { get { return b; } }
        public double C
        { get { return c; } }
        public UnitOfMeasure Unit
        { get { return unit; } }

        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
         
            // budowac dla default
            if (b == 0.1 && c == 0.1) // 1 param
            {
                switch (unit)
                {
                    case UnitOfMeasure.meter:
                        if (a <= 0 || a > 10)
                        { throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException"); }
                        else
                        { a = Math.Round(a, 3); }
                        break;
                    case UnitOfMeasure.centimeter:
                        if (a < 0.1 || a > 1000)
                        { throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException"); }
                        else
                        { a = Math.Round(a / 100, 2); }
                        break;
                    case UnitOfMeasure.milimeter:
                        if (a <= 1 || a > 10000 )
                        { throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException"); }
                        else
                        { a = Math.Round(a / 1000, 2); }
                        break;
                }
            }
            else if (c == 0.1) //2 params
            {
                switch (unit)
                {
                    case UnitOfMeasure.meter:
                        if (a < 0.1 || a > 10 || b < 0.1 || b > 10)
                        { throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException"); }
                        else
                        {
                            a = Math.Floor(a * 1000) / 1000;
                            b = Math.Floor(b * 1000) / 1000;
                        }
                        break;
                    case UnitOfMeasure.centimeter:
                        if (a < 0.1 || a > 1000 || b < 0.1 || b > 1000)
                        { throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException"); }
                        else
                        {
                            a = Math.Floor(a * 10) / 1000;
                            b = Math.Floor(b * 10) / 1000;
                        }
                        break;
                    case UnitOfMeasure.milimeter:
                        if (a <= 1 || a > 10000 || b <= 1 || b > 10000)
                        { throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException"); }
                        else
                        {
                            a = Math.Floor(a) / 1000;
                            b = Math.Floor(b) / 1000;
                        }
                        break;
                }
            }
            else // 3 params
            {
                switch (unit)
                {
                    case UnitOfMeasure.meter:
                        if (a < 0.1 || a > 10 || b < 0.1 || b > 10 || c < 0.1 || c > 10)
                        { throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException"); }
                        break;
                    case UnitOfMeasure.centimeter:
                        if (a < 0.1 || a > 1000 || b < 0.1 || b > 1000 || c < 0.1 || c > 1000)
                        { throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException"); }
                        else
                        {
                            a = (Math.Floor(a / 100 * 1000)) / 1000;
                            b = (Math.Floor(b / 100 * 1000)) / 1000;
                            c = (Math.Floor(c / 100 * 1000)) / 1000;
                        }
                        break;
                    case UnitOfMeasure.milimeter:
                        if (a <= 1 || a > 10000 || b <= 1 || b > 10000 || c < 1 || c > 10000)
                        { throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException"); }
                        else
                        {
                            a = (Math.Floor(a / 1000 * 1000)) / 1000;
                            b = (Math.Floor(b / 1000 * 1000)) / 1000;
                            c = (Math.Floor(c / 1000 * 1000)) / 1000;
                        }
                        break;
                }
            }
            

            this.a = a == default ? 0.1 : a;
            this.b = b == default ? 0.1 : b;
            this.c = c == default ? 0.1 : c;
            this.unit = unit == default ? UnitOfMeasure.meter : unit;

        }


        public string ToString(string format = "m", IFormatProvider formatProvider = null)
        {
            if (format == null)
            {
                format = "m";
            }
            else if (format != "mm" && format != "cm" && format != "m")
            {
                throw new FormatException("FormatException");
            }

            format = format.ToLower();

            double aConverted = 0, bConverted = 0, cConverted = 0;

            if (Unit == UnitOfMeasure.milimeter)
            {
                aConverted = A / 1000;
                bConverted = B / 1000;
                cConverted = C / 1000;
            }
            else if (Unit == UnitOfMeasure.centimeter)
            {
                aConverted = A / 100;
                bConverted = B / 100;
                cConverted = C / 100;
            }
            else if (Unit == UnitOfMeasure.meter)
            {
                aConverted = A;
                bConverted = B;
                cConverted = C;
            }
            else
            {
                throw new FormatException("This format is not supported.");
            }


            string aFormated = "", bFormated = "", cFormated = "";
            if (format == "m" || format == "")
            {
                format = "m";
                aFormated = aConverted.ToString("F3");
                bFormated = bConverted.ToString("F3");
                cFormated = cConverted.ToString("F3");
            }
            else if ((format == "cm"))
            {
                aFormated = (aConverted * 100).ToString("F1");
                bFormated = (bConverted * 100).ToString("F1");
                cFormated = (cConverted * 100).ToString("F1");
            }
            else if (format == "mm")
            {
                aFormated = (aConverted * 1000).ToString();
                bFormated = (bConverted * 1000).ToString();
                cFormated = (cConverted * 1000).ToString();
            }
            string result = $"{aFormated} {format} × {bFormated} {format} × {cFormated} {format}";
            return result;
        }
        public double Objetosc
        {         
            get { return Math.Round(ToMeters(A,unit) * ToMeters(A, unit) * ToMeters(A, unit), 9); }
        }
        public double Pole
        {
            get { return Math.Round(((ToMeters(A, unit) * ToMeters(B, unit) * 2) + (ToMeters(A, unit) * ToMeters(C, unit) * 2) + (ToMeters(B, unit) * ToMeters(C, unit) * 2)), 6); }
        }
        public double this[int index]
        {
            get
            {
                return index switch
                {
                    0 => A,
                    1 => B,
                    2 => C,
                };
            }
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public static bool operator ==(Pudelko? a, Pudelko? b)
        {
            if (a is null || b is null) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Pudelko? a, Pudelko? b)
        {
            if (a is null || b is null) return false;
            return !a.Equals(b);
        }
        public bool Equals(Pudelko? p)
        {
            if (p == null) return false;

            double[] firstArray = new double[3];
            double[] secondArray = new double[3];

            firstArray[0] = A;
            firstArray[1] = B;
            firstArray[2] = C;
            secondArray[0] = p.A;
            secondArray[1] = p.B;
            secondArray[2] = p.C;

            Console.WriteLine(firstArray[0] + secondArray[0]);
            Console.WriteLine(firstArray[1] + secondArray[1]);
            Console.WriteLine(firstArray[2] + secondArray[2]);

            Array.Sort(firstArray);
            Array.Sort(secondArray);

            if (firstArray[0] == secondArray[0] && firstArray[1] == secondArray[1] && firstArray[2] == secondArray[2]) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public IEnumerator<double> GetEnumerator()
        {
            yield return A;
            yield return B;
            yield return C;
        }
        public static double ToMeters(double input, UnitOfMeasure unit)
        {
            if(unit == UnitOfMeasure.meter)
            {
                return input;
            }
            else if(unit == UnitOfMeasure.centimeter)
            {
                return input / 100;
            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                return input / 1000;
            }
            else
            {
                throw new FormatException("FormatException");
            }
                    
        }

    }
}