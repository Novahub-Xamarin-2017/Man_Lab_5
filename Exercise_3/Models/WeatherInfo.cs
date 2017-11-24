using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise_3.Models;
namespace Exercise_3.Models
{
    public class WeatherInfo
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }

        public override string ToString()
        {
            var weather = "\n";
            foreach (var item in Weather)
            {
                weather += item.ToString() + "\n";
            }

            return $"Coord: {Coord}" +
                   $"\nWeather: {weather}" +
                   $"\nBase: {Base}" +
                   $"\nMain: {Main}" +
                   $"\nVisibility: {Visibility}" +
                   $"\nWind: {Wind}" +
                   $"\nClouds: {Clouds}" +
                   $"\nDt: {Dt}" +
                   $"\nSys: {Sys}" +
                   $"\nId: {Id}" +
                   $"\nName: {Name}" +
                   $"\nCod: {Cod}";
        }
    }
}
