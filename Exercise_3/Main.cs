using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public class Main
    {
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }

        public override string ToString() => $"\n\tTemp: {Temp}" +
                                             $"\n\tPressure: {Pressure}" +
                                             $"\n\tHumidity: {Humidity}" +
                                             $"\n\tTempMin: {TempMin}" +
                                             $"\n\tTempMax: {TempMax}";
    }
}
