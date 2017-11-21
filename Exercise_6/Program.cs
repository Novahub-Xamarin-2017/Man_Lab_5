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
            xmlFile.LoadXml(ReadFromFile(xmlFilePath));
            WriteToFile(JsonConvert.SerializeXmlNode(xmlFile), jsonFilePath);
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
