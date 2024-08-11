using System.Xml;

namespace XMLTextReader
{
    internal class TextReader
    {
        public static void Main(string[] args)
        {
            XmlTextReader reader = new XmlTextReader("C:\\Users\\Administrator\\Desktop\\CSharp\\Tasks\\Assignments\\XMLFiles\\Books.xml");
            Console.WriteLine(reader.Name);
            Console.WriteLine(reader.BaseURI);
            Console.WriteLine(reader.LocalName);
            while (reader.Read())
            {
                if (reader.HasValue)
                {
                    //Console.WriteLine("Name: "+reader.Value);
                    //Console.WriteLine("Node Depth: " + reader.Depth.ToString());
                    Console.WriteLine("Value: " + reader.Value);

                }
            }
        }
    }
}