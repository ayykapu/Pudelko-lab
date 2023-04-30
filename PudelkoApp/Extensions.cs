using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PudelkoLib
{
   public static class CompressionExtention
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
