using System;

namespace PudelkoLib
{
    public sealed class Pudelko
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
            
       
    }
}