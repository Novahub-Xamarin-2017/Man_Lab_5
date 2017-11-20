using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Retrofit.Net;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var listItem in GetListObjects())
            {
                Console.WriteLine(listItem.ToString());
            }
            Console.ReadKey();
        }

        static List<RootObject> GetListObjects()
        {
            var url = "https://jsonplaceholder.typicode.com";
            var restAdapter = new RestAdapter(url);
            IJsonPlaceHolder service = restAdapter.Create<IJsonPlaceHolder>();
            RestResponse<List<RootObject>> listResponse = service.Get();
            return listResponse.Data;
        }
    }
}
