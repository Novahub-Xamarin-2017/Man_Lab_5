using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Exercise_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonPath = "employees.json";
            var xmlPath = "employees.xml";
            ConvertJsonToXml(jsonPath, xmlPath);
            Console.ReadKey();
        }
        static void ConvertJsonToXml(string jsonInputPath, string xmlOutputPath)
        {
            var xmlString = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                Encoding.ASCII.GetBytes(File.ReadAllText(jsonInputPath)), new XmlDictionaryReaderQuotas())).ToString();
            File.WriteAllText(xmlOutputPath, xmlString, Encoding.UTF8);
        }

    }
}
