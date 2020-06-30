using System;
using System.IO;
using System.Text;
using System.Xml;

namespace XMLExamples
{
    class Program
    {
        private static StringBuilder sb;
        private static string Filename;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            sb = new StringBuilder();
            Filename = "Person.xml";
            //XMLWriter();
            //XMLReader();
            XMLDocument();
        }


        static void XMLWriter()
        {
            Person p = new Person
            {
                FirstName = "Alexander",
                LastName = "Tonchev"
            };

            Console.WriteLine("Writing xml file");

            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Person");
                writer.WriteAttributeString("Age", "40");
                writer.WriteElementString("FirstName", p.FirstName);
                writer.WriteElementString("LastName", p.LastName);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            File.WriteAllText(Filename, sb.ToString());
            //Console.Write(sb.ToString());
        }

        static void XMLReader()
        {
            Console.WriteLine("Reading xml file");
            XmlTextReader reader = new XmlTextReader(Filename);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.None:
                        break;
                    case XmlNodeType.Element:
                        Console.WriteLine("<" + reader.Name + ">");
                        break;
                    case XmlNodeType.Attribute:
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.CDATA:
                        break;
                    case XmlNodeType.EntityReference:
                        break;
                    case XmlNodeType.Entity:
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        break;
                    case XmlNodeType.Comment:
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentType:
                        break;
                    case XmlNodeType.DocumentFragment:
                        break;
                    case XmlNodeType.Notation:
                        break;
                    case XmlNodeType.Whitespace:
                        break;
                    case XmlNodeType.SignificantWhitespace:
                        break;
                    case XmlNodeType.EndElement:
                        Console.WriteLine("</" + reader.Name + ">");
                        break;
                    case XmlNodeType.EndEntity:
                        break;
                    case XmlNodeType.XmlDeclaration:
                        break;
                    default:
                        break;
                }
            }
        }

        private static void XMLDocument()
        {
            throw new NotImplementedException();
        }
    }
}
