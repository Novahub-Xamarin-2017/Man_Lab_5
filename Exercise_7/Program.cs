using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Exercise_7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> files = new List<string>()
            {
                "bus-services",
                "bus-services-5",
                "bus-services-7",
                "bus-services-8",
                "bus-services-11",
                "bus-services-12" 
            };
            files.ForEach(ConvertJsonToXml);
            Console.ReadKey();
        }
        static void ConvertJsonToXml(string fileName)
        {
            string fileInputPath = $"{fileName}.json";
            string fileOutputPath = $"{fileName}.xml";
            var xmlString = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                Encoding.UTF8.GetBytes(File.ReadAllText(fileInputPath)), new XmlDictionaryReaderQuotas())).ToString();
            File.WriteAllText(fileOutputPath, xmlString, Encoding.UTF8);
        }
    }
}
