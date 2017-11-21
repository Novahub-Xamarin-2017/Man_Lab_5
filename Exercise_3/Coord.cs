using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }

        public override string ToString() => $"\n\tLon: {Lon}" +
                                             $"\n\tLat: {Lat}";
    }
}
