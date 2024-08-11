using System.Xml;

namespace XMLWriteNode
{
    internal class WriteNode
    {
        public static void Main(string[] args)
        {
            XmlTextWriter writer = new XmlTextWriter("C:\\Users\\Administrator\\Desktop\\CSharp\\Tasks\\Assignments\\XMLFiles\\BooksDataWriteNode.xml", null);
            XmlTextReader reader = new XmlTextReader("C:\\Users\\Administrator\\Desktop\\CSharp\\Tasks\\Assignments\\XMLFiles\\Books.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    writer.WriteNode(reader, true);
                }
            }
            writer.Close();
        }
    }
}