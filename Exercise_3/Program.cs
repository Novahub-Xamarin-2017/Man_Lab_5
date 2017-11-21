using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Retrofit.Net;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in GetWeathers())
            {
                Console.WriteLine(item);   
            }
            Console.ReadKey();
        }

        static List<Weathers> GetWeathers()
        {
            var url = "http://samples.openweathermap.org";
            var restAdapter = new RestAdapter(url);
            ICityWeather service = restAdapter.Create<ICityWeather>();
            RestResponse<List<Weathers>> listResponse = service.GetWeatherByCityName("London", "uk");
            return listResponse.Data;
        }
    }
}
