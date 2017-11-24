using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3.Models
{
    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public double Message { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }

        public override string ToString() => $"\n\tType: {Type}" +
                                             $"\n\tId: {Id}" +
                                             $"\n\tMessage: {Message}" +
                                             $"\n\tCountry: {Country}" +
                                             $"\n\tSunrise: {Sunrise}" +
                                             $"\n\tSunset: {Sunset}";
    }
}
