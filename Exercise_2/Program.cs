using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = ConvertJarrayToListObject(Get());
            foreach (var listItem in list)
            {
                Console.WriteLine(listItem.ToString());
            }
            Console.ReadKey();
        }

        static JArray Get()
        {
            var uri = "https://jsonplaceholder.typicode.com/posts";
            try
            {
                using (var client = new WebClient())
                {
                    return JArray.Parse(client.DownloadString(uri));
                }
            }
            catch (WebException we)
            {
                using (var sr = new StreamReader(we.Response.GetResponseStream()))
                {
                    Console.WriteLine(sr.ReadToEnd());
                    throw;
                }
            }
        }
        static List<RootObject> ConvertJarrayToListObject(JArray jArray)
        {
            var listObject = new List<RootObject>();
            foreach (var jObject in jArray)
            {
                listObject.Add(JsonConvert.DeserializeObject<RootObject>(jObject.ToString()));
            }
            return listObject;
        }
    }
}
