using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise_3.Models;
using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;

namespace Exercise_3.Service
{
    public interface ICityWeather
    {
        [Get("/data/2.5/weather?q={cityName},{countryCode}&appid=b1b15e88fa797225412429c1c50c122a1")]
        RestResponse<List<WeatherInfo>> GetWeatherByCityName([Path("cityName")] string cityName, [Path("countryCode")] string countryCode);
    }
}
