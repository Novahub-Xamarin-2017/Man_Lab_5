using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public override string ToString() => $"\n\tId: {Id}" +
                                             $"\n\tMain: {Main}" +
                                             $"\n\tDescription: {Description}" +
                                             $"\n\tIcon: {Icon}";
    }

}
