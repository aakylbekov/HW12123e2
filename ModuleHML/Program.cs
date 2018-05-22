using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace ModuleXML
{
    public class HabrNews
    {
        public string title { get; set; }
        public string link { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List<HabrNews> habrNews = new List<HabrNews>();

            XmlDocument doc = new XmlDocument();
            doc.Load("https://habrahabr.ru/rss/interesting/");

            var rootElement = doc.DocumentElement;

            foreach (XmlNode item in rootElement.ChildNodes)
            {
                Console.WriteLine(item.Name);
                foreach (XmlNode ch in item.ChildNodes)
                {
                    Console.WriteLine(ch.Name);
                    if (ch.Name == "item")
                    {
                        HabrNews hNews = new HabrNews();

                        foreach (XmlNode news in ch.ChildNodes)
                        {
                            if (news.Name == "title")
                            {
                                hNews.title = news.InnerText;
                            }
                            else if (news.Name == "link")
                            {
                                hNews.link = news.InnerText;
                            }

                            else if (news.Name == "description")
                            {
                                hNews.description = news.InnerText;
                            }
                            else if (news.Name == "pubDate")
                            {
                                hNews.date = DateTime.Parse(news.InnerText);
                            }
                            habrNews.Add(hNews);
                            Console.WriteLine("--->" + news.Name);


                        }
                    }
                }
            }
            string s = "";
            foreach (var item in habrNews)
            {
                s += item.title + " " + item.link + " " + item.description + " " + item.date;
            }


            FileInfo filet1 = new FileInfo("");
            FileStream fst1 = filet1.Create();
            StreamWriter strt1 = new StreamWriter(s);
            fst1.Close();
            strt1.Close();

          

            foreach (var item in habrNews)
            {
                Console.WriteLine(item.title);
                Console.WriteLine(item.link);
                Console.WriteLine("");
            }
            var test = "";

            //XmlDocument doc = new XmlDocument();
            //XmlElement root = doc.CreateElement("User");
            //XmlElement name = doc.CreateElement("Name");
            //name.InnerText = "Yevgeniy";

            //XmlAttribute atr = doc.CreateAttribute("IIN");
            //atr.InnerText = "5553656";
            //name.Attributes.Append(atr);
            ////name.SetAttribute("IIN", "5553656")
            //root.AppendChild(name);
            //doc.AppendChild(root);
            //doc.Save("UserHello.xml");
        }
    }
}
