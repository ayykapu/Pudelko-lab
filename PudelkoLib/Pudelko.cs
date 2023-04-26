using System;

namespace PudelkoLib
{
    public sealed class Pudelko
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
        private readonly UnitOfMeasureType UnitOfMeasure;

        public Pudelko(double a, double b, double c, UnitOfMeasureType unitOfMeasure)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            UnitOfMeasure = unitOfMeasure;
        }
        //implementacja getterow
        public double A
        { get { return a; } }
        public double B
        { get { return b; } }
        public double C
        { get { return c; } }
        public UnitOfMeasureType UnitOfMeasureType
        { get { return UnitOfMeasure; } }
        //ToString()
        public override string ToString()
        {
            double aConverted = 0, bConverted = 0, cConverted = 0;
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
            return $"{aConverted}m x {bConverted}m x {cConverted}m";
        }

    }
}
