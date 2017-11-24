using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Exercise_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonPath = "books.json";
            var xmlPath = "books.xml";
            ConvertJsonToXml(jsonPath, xmlPath);
            Console.ReadKey();
        }

        static void ConvertJsonToXml(string jsonInputPath, string xmlOutputPath)
        {
            var xmlString = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                Encoding.ASCII.GetBytes(ReadFile(jsonInputPath)), new XmlDictionaryReaderQuotas())).ToString();
            WriteFile(xmlOutputPath, xmlString);
        }

        static string ReadFile(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        static void WriteFile(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content, Encoding.UTF8);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
