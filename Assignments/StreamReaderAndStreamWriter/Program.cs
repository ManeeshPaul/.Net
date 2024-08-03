namespace StreamReaderAndStreamWriter
{
    internal class StreamReaderAndStreamWriter
    {
        public static void Main(string[] arg)
        {

            string filePath = @"C:\Users\Administrator\Desktop\CSharp\File_Handling\Sample.txt";


            //StreamWriter streamWriter = new StreamWriter(filePath);  //this will overwrite the file
            /*
            StreamWriter streamWriter = new StreamWriter(filePath,true);  //to append to the file
            Console.Write("Enter the data : ");


            string writeData=Console.ReadLine();    
            streamWriter.Write(writeData); 
            streamWriter.Flush();   
            streamWriter.Close();
            */

            StreamReader sr = new StreamReader(filePath);
            Console.WriteLine("File contents are \n");

            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string data = sr.ReadLine();

            while (data != null)
            {
                Console.WriteLine(data);
                data = sr.ReadLine();
            }



        }
    }
}