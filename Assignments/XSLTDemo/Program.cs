using System.Xml.Xsl;

namespace XSLTDemo
{
    internal class XSLTDemo
    {
        public static void Main()
        {
            XslTransform xslt = new XslTransform();
            xslt.Load("C:\\Users\\Administrator\\Desktop\\CSharp\\Tasks\\Assignments\\XSLT\\Sample.xsl");
            xslt.Transform("C:\\Users\\Administrator\\Desktop\\CSharp\\Tasks\\Assignments\\XMLFiles\\Books.xml", "file.html");


            //Here file.html path will be "C:\Users\Administrator\Desktop\CSharp\FirstProject\Project10_08\bin\Debug\net6.0\file.html"
        }
    }
}