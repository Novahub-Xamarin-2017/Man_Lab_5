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
            ConvertJsonToXml("bus-services.json", "bus-services.xml");
            ConvertJsonToXml("bus-services-5.json", "bus-services-5.xml");
            ConvertJsonToXml("bus-services-7.json", "bus-services-7.xml");
            ConvertJsonToXml("bus-services-8.json", "bus-services-8.xml");
            ConvertJsonToXml("bus-services-11.json", "bus-services-11.xml");
            ConvertJsonToXml("bus-services-12.json", "bus-services-12.xml");
            Console.ReadKey();
        }
        static void ConvertJsonToXml(string jsonInputPath, string xmlOutputPath)
        {
            var xmlString = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                Encoding.UTF8.GetBytes(ReadFromFile(jsonInputPath)), new XmlDictionaryReaderQuotas())).ToString();
            WriteToFile(xmlString, xmlOutputPath);
        }
        static string ReadFromFile(string filePath)
        {
            string strOutput = "";
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        strOutput += line + "\n";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return strOutput;
        }

        static void WriteToFile(string content, string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
