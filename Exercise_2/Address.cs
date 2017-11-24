using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }

        public override string ToString() => $"\n\tStreet: {Street}" +
                                             $"\n\tSuite: {Suite}" +
                                             $"\n\tCity: {City}" +
                                             $"\n\tZipcode: {Zipcode}" +
                                             $"\n\tGeo: {Geo}";
    }
}
