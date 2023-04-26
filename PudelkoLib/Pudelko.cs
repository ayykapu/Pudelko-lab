using System;

namespace PudelkoLib
{
    public sealed class Pudelko
    {
        private double a;
        private double b;
        private double c;
        private UnitOfMeasureType unitOfMeasure;

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