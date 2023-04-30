using System;
using PudelkoLib;
using PudelkoApp;

namespace PudelkoLib
{
    public class ExtensionMethods
    {
        public static Pudelko Kompresuj(Pudelko p)
        {
            if (p == null)
            {
                throw new ArgumentNullException("ArgumentNullException");
            }

            double volume = p.A * p.B * p.C;
            double edge = Math.Pow(volume, 1.0 / 3.0);

            return new Pudelko(edge, edge, edge);
        }

    }
}
