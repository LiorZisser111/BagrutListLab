using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagrutListLab
{
    public class Ranges
    {
        private int high;
        private int low;


        public Ranges(int high, int low)
        {
            this.high = high;
            this.low = low;
        }

        public int GetHigh()
        {
            return high;
        }

        public int GetLow()
        {
            return low;
        }

        public override string ToString()
        {
            return '['+high+','+low+"]";
        }
    }
}
