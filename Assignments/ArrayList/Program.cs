using System.Collections;

namespace ArrayListProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList aList = new ArrayList();
            string str = "Arun";
            int a = 10;
            DateTime dt = DateTime.Parse("30-08-1998");

            aList.Add(str);
            aList.Add(a);
            aList.Add(dt);

            foreach (var val in aList)
            {
                Console.WriteLine(val);
            }


            Console.WriteLine("**************************");

            Hashtable ht = new Hashtable();
            ht.Add("cs", "cs.net");
            ht.Add("vb", "vb.net");
            ht.Add("asp", "asp.net");

            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}