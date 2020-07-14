using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XMLExamples
{
    class Program
    {
        private static StringBuilder sb;
        private static string Filename;

        static void Main(string[] args)
        {
            sb = new StringBuilder();
            Filename = "Person.xml";

            //XMLWriter();
            //XMLReader();
            //XMLDocument();

            //XPath();

            //LinqToXMLExample1();
            //LinqToXMLExample2();
            //LinqToXMLExample3();
            //LinqToXMLExample4();
            LinqToXMLExample5();
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

        private static void LinqToXMLExample1()
        {
            //3 ways to obtain the part number attribute value for every item element in the purchase order
            XElement purchaseOrder = XElement.Load("PurchaseOrder.xml");
            var query = purchaseOrder.Descendants("Item").Attributes("PartNumber");
            foreach (var item in query)
            {
                Console.WriteLine(item.Value);
            }
            Console.WriteLine();

            var query2 = purchaseOrder.Descendants("Item").Attributes("PartNumber").Select(x => x.Value);
            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var query3 = from item in purchaseOrder.Descendants("Item")
                         select item.Attribute("PartNumber").Value;

            foreach (var item in query3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void LinqToXMLExample2()
        {
            //2 ways to obtain a list, sorted by part number, of the items with a value greater than $100
            XElement purchaseOrder = XElement.Load("PurchaseOrder.xml");
            var query = purchaseOrder.Descendants("Item")
                                     .Where(x => (decimal.Parse(x.Element("USPrice").Value)) > 100)
                                     .OrderBy(x => x.Attribute("PartNumber").Value);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var query2 = from item in purchaseOrder.Descendants("Item")
                         where ((decimal)item.Element("USPrice")) > 100
                         orderby (string)item.Attribute("PartNumber")
                         select item;

            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }

        }

        private static void LinqToXMLExample3()
        {
            //Create a new xml tree by filtering only the items with price >100 from the purchase order
            XElement purchaseOrder = XElement.Load("PurchaseOrder.xml");
            var query = purchaseOrder.Descendants("Items").Elements("Item").Where(item => (decimal)item.Element("USPrice") > 100);

            XElement modifiedPurchaseOrder = new XElement("FilteredItems", query);

            modifiedPurchaseOrder.Save("FilteredItems.xml");
            Console.WriteLine(modifiedPurchaseOrder.ToString());
        }

        private static void LinqToXMLExample4()
        {
            XElement people = new XElement("People",
                  new XElement("Person",
                    new XAttribute("Age", "18"),
                    new XElement("Name", "Penko"),
                    new XElement("Age", "18")),
                  new XElement("Person",
                    new XElement("Name", "Sa6ko"),
                    new XElement("Age", "20"))
                );

            Console.WriteLine(people);
        }

        private static void LinqToXMLExample5()
        {
            XNamespace billCo = "http://www.billco.com";
            XNamespace johnCo = "http://www.john.com";
            XElement people = new XElement("People",
                new XElement("Person",
                    new XElement("Name", "Penko")),
                new XElement("Person",
                    new XElement("Name", "Sa6ko")));

            Console.WriteLine(people);

        }
    }
}
