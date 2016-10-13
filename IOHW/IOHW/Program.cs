using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace IOHW
{
    public class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\Users\\Bishop Clara\\Documents\\PlantNumbers.txt";

            StreamWriter sw = new StreamWriter(fileName, false);
            
            for (int i = 0; i < 101; i++)
            {
                sw.WriteLine(string.Format("The number is {0}", i));
            }
            sw.Close();

            List<Num> Number = new List<Num>();
            StreamReader sr = new StreamReader(fileName);

            if (File.Exists(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    string[] values = temp.Split('\n');
                    Num newNum = new Num();
                    newNum.Number = values[0];

                    Number.Add(newNum);
                    Console.WriteLine(newNum);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
            sw.Close();
            Console.WriteLine("");

            List<Plants> Nursery = new List<Plants>();

            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Bishop Clara\\Documents\\plant_catalog.xml");

            XmlNode catnode = doc.DocumentElement.SelectSingleNode("/catalog");

            foreach(XmlNode child in catnode.ChildNodes)
            {
                 Plants plant = new Plants();
                foreach(XmlNode grandchild in child.ChildNodes)
                {
                    switch (grandchild.Name)
                    {
                        case "COMMON":
                            {
                                plant.COMMON = grandchild.InnerText;
                                break;
                            }

                        case "BOTANICAL":
                            {
                                plant.BOTANICAL = grandchild.InnerText;
                                break;
                            }

                        case "ZONE":
                            {
                                plant.ZONE = Convert.ToInt32(grandchild.InnerText);
                                break;
                            }

                        case "LIGHT":
                            {
                                plant.LIGHT = grandchild.InnerText;
                                break;
                            }

                        case "PRICE":
                            {
                                plant.PRICE = Convert.ToDouble(grandchild.InnerText);
                                break;
                            }

                        case "AVAILABILITY":
                            {
                                plant.AVAILABILITY = Convert.ToDateTime(grandchild.InnerText);
                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }
                }
                Nursery.Add(plant);
            }

            for (int i = 0; i < Nursery.Count; i++)
            {
                Console.WriteLine(string.Format("Plant - {0} ", Nursery[i].COMMON));
                Console.WriteLine(string.Format("Plant type - {0}", Nursery[i].BOTANICAL));
                Console.WriteLine(string.Format("Light - {0}", Nursery[i].LIGHT));
                Console.WriteLine(string.Format("Price - {0}", Nursery[i].PRICE));
                Console.WriteLine(string.Format("Zone - {0}", Nursery[i].ZONE));
                Console.WriteLine(string.Format("Available by - {0}", Nursery[i].AVAILABILITY));
                Console.WriteLine(" ");
            }

        }
    }
}
