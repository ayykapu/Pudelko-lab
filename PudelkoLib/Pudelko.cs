using System;

namespace PudelkoLib
{
    public sealed class Pudelko : IFormattable
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
        private readonly UnitOfMeasureType unitOfMeasure;

        public Pudelko(double a, double b, double c, UnitOfMeasureType unitOfMeasure)
        {
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


        public string ToString(string format, IFormatProvider formatProvider)
        {
            format = format.ToUpper();
            double aConverted = 0, bConverted = 0, cConverted = 0;
            if (string.IsNullOrEmpty(format))
            { format = "M"; }

            if (UnitOfMeasure == UnitOfMeasureType.milimeters)
            {
                aConverted = a / 1000;
                bConverted = b / 1000;
                cConverted = c / 1000;
            }
            else if (UnitOfMeasure == UnitOfMeasureType.centimeters)
            {
                aConverted = a / 100;
                bConverted = b / 100;
                cConverted = c / 100;
            }
            else if (UnitOfMeasure == UnitOfMeasureType.meters)
            {
                aConverted = a;
                bConverted = b;
                cConverted = c;
            }
            double aFormated = 0, bFormated = 0, cFormated = 0;
            if (format == "M")
            {
                aFormated = aConverted;
                bFormated = bConverted;
                cFormated = cConverted;
            }
            else if ((format == "CM"))
            {
                aFormated = aConverted * 100;
                bFormated = bConverted * 100;
                cFormated = cConverted * 100;
            }
            else if (format == "MM")
            {
                aFormated = aConverted * 1000;
                bFormated = bConverted * 1000;
                cFormated = cConverted * 1000;
            }
            string result = aFormated.ToString("F3") + format.ToString() + " x " + bFormated.ToString("F3") + format.ToString() + " x " + cFormated.ToString("F3") + format.ToString();
            return result;
        }
    }
}