using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mo_lab6_new
{
    class Specimen
    {
        public double x, y;
        public double fit;

        public Specimen(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /*public Comparer<Specimen> comparer(Specimen s1, Specimen s2)
        {
            if(s1.fit > s2.fit)
            {
                return Comparer<>
            }
        }
        */
    }
}
