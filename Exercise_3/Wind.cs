using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }

        public override string ToString() => $"\n\tSpeed: {Speed}" +
                                             $"\n\tDeg: {Deg}";
    }
}
