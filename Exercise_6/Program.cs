using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Exercise_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlPath = "books.xml";
            var jsonPath = "books.json";
            ConvertXmlToJson(xmlPath, jsonPath);
            Console.ReadKey();
        }

        static void ConvertXmlToJson(string xmlFilePath, string jsonFilePath)
        {
            XmlDocument xmlFile = new XmlDocument();
            xmlFile.LoadXml(File.ReadAllText(xmlFilePath));
            File.WriteAllText(jsonFilePath, JsonConvert.SerializeXmlNode(xmlFile), Encoding.UTF8);
        }
    }
}
