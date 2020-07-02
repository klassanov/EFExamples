using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;

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
            //XMLDocument();
            XPath();
        }


        static void XMLWriter()
        {
            Person p = new Person
            {
                FirstName = "Alexander",
                LastName = "Tonchev"
            };

            Console.WriteLine("Writing xml file with XmlWriter");

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
            Console.WriteLine("Reading xml file with XmlTextReader");
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
            //Read
            Console.WriteLine("Reading with XMLDocument");
            XmlDocument rdoc = new XmlDocument();
            rdoc.Load(Filename);
            XmlNodeList nodes = rdoc.ChildNodes;
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine($"{node.Name}: {node.InnerXml}");
            }

            //Write
            Console.WriteLine("Writing with XMLDocument");
            XmlDocument wdoc = new XmlDocument();
            XmlElement personElement = wdoc.CreateElement("Person");
            personElement.SetAttribute("Age", "41");
            wdoc.AppendChild(personElement);

            XmlElement firstNameElement = wdoc.CreateElement("FirstName");
            firstNameElement.InnerText = "Penko";
            personElement.AppendChild(firstNameElement);

            XmlElement lastNameElement = wdoc.CreateElement("LastName");
            lastNameElement.InnerText = "Patarinski";
            personElement.AppendChild(lastNameElement);

            wdoc.Save(Filename);
        }

        private static void XPath()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("bookstore.xml");
            XPathNavigator nav = xdoc.CreateNavigator();
            string query = "//book/title[@lang='bg']";
            XPathNodeIterator iterator = nav.Select(query);
            Console.WriteLine(iterator.Count);
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current.Value);
            }
        }
    }
}
