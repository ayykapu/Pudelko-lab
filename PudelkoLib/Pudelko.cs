using System;
using System.Globalization;

namespace PudelkoLib
{
    public sealed class Pudelko : IFormattable
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
        private readonly UnitOfMeasureType unitOfMeasure;

        public Pudelko(double a = 10, double b = 10, double c = 10, UnitOfMeasureType unitOfMeasure = UnitOfMeasureType.meter)
        {
            if (((a < 0 || a > 10 || b < 0 || b > 10 || c < 0 || c > 10) && (unitOfMeasure == UnitOfMeasureType.meter))
            || ((a < 0 || a > 1000 || b < 0 || b > 1000 || c < 0 || c > 1000) && (unitOfMeasure == UnitOfMeasureType.centimeter))
            || ((a < 0 || a > 10000 || b < 0 || b > 10000 || c < 0 || c > 10000) && (unitOfMeasure == UnitOfMeasureType.milimeter)))        
            {
                throw new ArgumentOutOfRangeException("The box size is incorrect. Try different size.");
            }

            this.a = a;
            this.b = b;
            this.c = c;
            this.unitOfMeasure = unitOfMeasure;
        }
        public double A
        { get { return a; } }
        public double B
        { get { return b; } }
        public double C
        { get { return c; } }
        public UnitOfMeasureType UnitOfMeasure
        { get { return unitOfMeasure; } }


        public string ToString(string format, IFormatProvider formatProvider = null)
        {


            format = format.ToLower();
            double aConverted = 0, bConverted = 0, cConverted = 0;

            if (UnitOfMeasure == UnitOfMeasureType.milimeter)
            {
                aConverted = a / 1000;
                bConverted = b / 1000;
                cConverted = c / 1000;
            }
            else if (UnitOfMeasure == UnitOfMeasureType.centimeter)
            {
                aConverted = a / 100;
                bConverted = b / 100;
                cConverted = c / 100;
            }
            else if (UnitOfMeasure == UnitOfMeasureType.meter)
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
    }
}