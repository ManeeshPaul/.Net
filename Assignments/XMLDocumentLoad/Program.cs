using System.Xml;

namespace XMLDocumentLoad
{
    internal class XmlDOcumenyLoad
    {
        public static void Main()      //need to remove error
        {
            XmlDocument xmlDoc = new XmlDocument();
            string filename = "C:\\Users\\Administrator\\Desktop\\CSharp\\Tasks\\Assignments\\XMLFiles\\Books.xml";
            xmlDoc.Load(filename);
            xmlDoc.Save(Console.Out);

            Console.WriteLine("\n =============================");

            XmlDocument xmlDoc1 = new XmlDocument();
            XmlTextReader reader = new XmlTextReader("C:\\Users\\Administrator\\Desktop\\CSharp\\Tasks\\Assignments\\XMLFiles\\Books.xml");
            xmlDoc1.Load(reader);
            xmlDoc1.Save(Console.Out);

            

            //------------------------------------------

            string fragmentFilename = "C:\\Users\\Administrator\\Desktop\\CSharp\\Tasks\\Assignments\\XMLFiles\\Fragment.xml";
            using (XmlWriter writer = XmlWriter.Create(fragmentFilename, new XmlWriterSettings { Indent = true }))
            {
                XmlDocumentFragment xoc = xmlDoc.CreateDocumentFragment();
                xoc.InnerXml = "<NewRecord>write some demo sample text</NewRecord>";
                Console.WriteLine(xoc.InnerXml);

                // Add the new fragment to the original XML document and save it
                XmlNode root = xmlDoc.DocumentElement;
                root.AppendChild(xoc);
                xmlDoc.Save(writer);
            }
            //Remove child

            string filename2 = "C:\\Users\\Administrator\\Desktop\\CSharp\\Tasks\\Assignments\\XMLFiles\\Fragment.xml";

            xmlDoc.Load(filename2);
            XmlNode nodeToRemove = xmlDoc.SelectSingleNode("//NewRecord"); // Selects the first <NewRecord> node
            if (nodeToRemove != null)
            {
                nodeToRemove.ParentNode.RemoveChild(nodeToRemove);
                Console.WriteLine("Removed node:");
                xmlDoc.Save(Console.Out);
                //using (XmlWriter writer = XmlWriter.Create(fragmentFilename, new XmlWriterSettings { Indent = true }))
                //{
                //    xmlDoc.Save(writer);                      //this is for remove the node from actual file
                //}
            }
            else
            {
                Console.WriteLine("Node to remove not found.");
            }


            // Select the node to replace (example: first <Book> node)
            XmlNode nodeToReplace = xmlDoc.SelectSingleNode("//book");
            if (nodeToReplace != null)
            {
                // Create a new element to replace the old node
                XmlElement newElement = xmlDoc.CreateElement("Book");
                newElement.SetAttribute("title", "Replaced Book Title");
                newElement.SetAttribute("author", "Replaced Book Author");

                // Replace the old node with the new element
                XmlNode oldNode = nodeToReplace.ParentNode.ReplaceChild(newElement, nodeToReplace);

                // Output the replaced node to the console
                Console.WriteLine("Replaced node:");
                Console.WriteLine(newElement.OuterXml);

                // Save the updated XML document back to the file
                //xmlDoc.Save(fragmentFilename);
            }
            else
            {
                Console.WriteLine("Node to replace not found.");
            }
        }
    }
}