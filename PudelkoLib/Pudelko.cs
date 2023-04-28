using System;
using System.Globalization;
using System.IO.Enumeration;

namespace PudelkoLib
{
    public sealed class Pudelko : IFormattable
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
        private readonly UnitOfMeasure unit;

        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            Assumptions(a, b, c, unit);


            void Assumptions(double a, double b, double c, UnitOfMeasure unit)
            {
                if (unit == UnitOfMeasure.meter)
                {
                    if (a == 0.1 && b == 0.1 && c == 0.1) { }
                    else if ((a < 0.1 || a > 10 || b < 0.1 || b > 10 || c < 0.1 || c > 10))
                    {
                        throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException");
                    }
                }
                else if (unit == UnitOfMeasure.centimeter)
                {
                    if (a == 0.1 && b == 0.1 && c == 0.1) { }
                    if (a < 0 || a > 10000 || b < 0 || b > 10000 || 0 < 1 || c > 10000)
                    {
                        throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException");
                    }
                }
                else if (unit == UnitOfMeasure.milimeter)
                {
                    if (a < 0 || a > 10000 || b < 0 || b > 10000 || 0 < 1 || c > 10000)
                    {
                        throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException");
                    }
                }


            }

            if (unit == UnitOfMeasure.centimeter)
            {
                a *= 0.01;
            }

            this.a = a == default ? 0.1 : a;
            this.b = b == default ? 0.1 : b;
            this.c = c == default ? 0.1 : c;
            this.unit = unit == default ? UnitOfMeasure.meter : unit;
        }
        public double A
        { get { return a; } }
        public double B
        { get { return b; } }
        public double C
        { get { return c; } }
        public UnitOfMeasure Unit
        { get { return unit; } }

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
                aConverted = a / 1000;
                bConverted = b / 1000;
                cConverted = c / 1000;
            }
            else if (Unit == UnitOfMeasure.centimeter)
            {
                aConverted = a / 100;
                bConverted = b / 100;
                cConverted = c / 100;
            }
            else if (Unit == UnitOfMeasure.meter)
            {
                aConverted = a;
                bConverted = b;
                cConverted = c;
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
            get { return Math.Round((a * b * c),9); }
        }
        public double Pole
        {
            get { return Math.Round((a * b * 2 + a * c * 2 + b * c * 2), 6); }
        }
    }
}