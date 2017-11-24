using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }

        public override string ToString() => $"\n\tLat: {Lat}" +
                                             $"\n\tLng: {Lng}";

    }
}
