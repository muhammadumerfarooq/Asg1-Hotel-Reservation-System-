using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StandardRoom;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Collections;

namespace Assignment1_Web
{
    class Program
    {
        public void update ()
        {
            var doc = XDocument.Load("Standard.xml");
            var node = doc.Descendants("Customer").FirstOrDefault(cd => cd.Element("FloorNo").Value == "3");
            node.SetElementValue("Name","UmerFarooq");
            doc.Save("Standard.xml");
        }

        public void read()
        {
            XmlReader reader = XmlReader.Create("Test.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write(" " + reader.Name);
                        Console.Write(":");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(" "+reader.Value);
                        break;
                  /*  case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write(" " + reader.Name);
                        Console.WriteLine(" ");
                        break;*/
                }
                
            }
        }
 public void write()
        {
            if (File.Exists("Test.xml") == false)
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create("Test.xml", xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("School");

                    xmlWriter.WriteStartElement("Student");
                    xmlWriter.WriteElementString("FirstName", "Umer");
                    xmlWriter.WriteElementString("LastName", "Farooq");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }
            else
            {
                XDocument xDocument = XDocument.Load("Test.xml");
                XElement root = xDocument.Element("School");
                IEnumerable<XElement> rows = root.Descendants("Student");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(
                   new XElement("Student",
                   new XElement("FirstName", "Saba"),
                   new XElement("LastName", "Umer")));
                xDocument.Save("Test.xml");
            }
        }
        static void Main(string[] args)
        {
            Hotel h = new Hotel();

            Boolean c = true;
            int choice=0;
            while (c)
            {
                Console.WriteLine(" Welcome To Our Guest House ");
                Console.WriteLine(" Press 1 to Search for Free Room");
                Console.WriteLine(" Press 2 to Search for Customer Info");
                Console.WriteLine(" Press 3 to Reserve Room");
                Console.WriteLine(" Press 4 to Generate Report ");
                Console.WriteLine(" Press 5 to Exit ");
                choice=int.Parse(Console.ReadLine());

                if (choice==1)
                {
                    int op = 0;
                    Console.WriteLine(" Press 1 to Search Suite Free Room");
                    Console.WriteLine(" Press 2 to Search Junior Suite Free Room");
                    Console.WriteLine(" Press 3 to Search Standard Free Room");
                    Console.WriteLine(" Press 4 to Search Moderate Free Room");
                    Console.WriteLine(" Press 5 to Search Superior Free Room");
                    op= int.Parse(Console.ReadLine());
                    if (op==1)
                    h.ShowFreeRoom("Suite");
                    if (op == 2)
                        h.ShowFreeRoom("Junior Suite");
                    if (op == 3)
                        h.ShowFreeRoom("Standard");
                    if (op == 4)
                        h.ShowFreeRoom("Moderate");
                    if (op == 5)
                        h.ShowFreeRoom("Superior");

                }
                if (choice==2)
                {
                    int op = 0;
                    Console.WriteLine(" Press 1 to Search Suite Customer info");
                    Console.WriteLine(" Press 2 to Search Junior Suite Free Customer info");
                    Console.WriteLine(" Press 3 to Search Standard Free Customer info");
                    Console.WriteLine(" Press 4 to Search Moderate Free Customer info");
                    Console.WriteLine(" Press 5 to Search Superior Free Customer info");
                    op = int.Parse(Console.ReadLine());
                    if (op == 1)
                    {
                        string name;
                        Console.WriteLine(" Enter Name ");
                      
                        name = Console.ReadLine();
                        int id;
                        Console.WriteLine(" Enter Id ");
                        id = int.Parse(Console.ReadLine());
                     

                        h.Suite_roominfo(name,id);
                    }
                    if (op == 2)
                    {
                        string name;
                        Console.WriteLine(" Enter Name ");

                        name = Console.ReadLine();
                        int id;
                        Console.WriteLine(" Enter Id ");
                        id = int.Parse(Console.ReadLine());

                        h.Junior_Suite_roominfo(name, id);
                    }
                    if (op == 3)
                    {
                        string name;
                        Console.WriteLine(" Enter Name ");

                        name = Console.ReadLine();
                        int id;
                        Console.WriteLine(" Enter Id ");
                        id = int.Parse(Console.ReadLine());

                        h.StandardRoom_roominfo(name, id);

                    }
                    if (op == 4)
                    {
                        string name;
                        Console.WriteLine(" Enter Name ");

                        name = Console.ReadLine();
                        int id;
                        Console.WriteLine(" Enter Id ");
                        id = int.Parse(Console.ReadLine());
                        h.Moderate_roominfo(name, id);
                    }
                    if (op == 5)
                    {

                        string name;
                        Console.WriteLine(" Enter Name ");

                        name = Console.ReadLine();
                        int id;
                        Console.WriteLine(" Enter Id ");
                        id = int.Parse(Console.ReadLine());

                        h.Superior_roominfo(name, id);
                    }
                }
                if (choice==3)
                {


                    int op = 0;
                    Console.WriteLine(" Press 1 to Search Suite Customer info");
                    Console.WriteLine(" Press 2 to Search Junior Suite Free Customer info");
                    Console.WriteLine(" Press 3 to Search Standard Free Customer info");
                    Console.WriteLine(" Press 4 to Search Moderate Free Customer info");
                    Console.WriteLine(" Press 5 to Search Superior Free Customer info");
                    op = int.Parse(Console.ReadLine());



                    if (op == 1)
                    {
                       
                        int id;
                        Console.WriteLine(" Enter FloorNo ");
                        id = int.Parse(Console.ReadLine());
                        h.Suite_ReservedCustomer(id);
                    }
                    if (op == 2)
                    {
                        int id;
                        Console.WriteLine(" Enter FloorNo ");
                        id = int.Parse(Console.ReadLine());
                        h.Junior_Suite_ReservedCustomer(id);
                    }
                    if (op == 3)
                    {
                        int id;
                        Console.WriteLine(" Enter FloorNo ");
                        id = int.Parse(Console.ReadLine());

                        h.StandardRoom_ReservedCustomer(id);
                    }
                    if (op == 4)
                    {
                        int id;
                        Console.WriteLine(" Enter FloorNo ");
                        id = int.Parse(Console.ReadLine());

                        h.Moderate_ReservedCustomer(id);
                    }

                    if (op == 5)
                    {
                        int id;
                        Console.WriteLine(" Enter FloorNo ");
                        id = int.Parse(Console.ReadLine());

                        h.Superior_ReservedCustomer(id);
                    }
                }

                if (choice==4)
                    h.GenerateReport();

                if (choice == 5)
                    c = false;
            }

            

            Console.ReadLine();

        }
    }
}
