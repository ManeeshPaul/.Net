namespace FileHandlingProject
{
    internal class FileHandling
    {
        public static void Main(string[] arg)
        {
            string filePath = @"C:\Users\Administrator\Desktop\CSharp\File_Handling\Sample.txt";

            //FileStream fileStream = new FileStream(filePath, FileMode.Create);            //Creating file
            /*
            FileStream fileStream = new FileStream(filePath, FileMode.Append);

            byte[] bytes = Encoding.Default.GetBytes("Hello welcome");
            fileStream.Write(bytes, 0, bytes.Length);       
            fileStream.Close();

            */

            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            string Data;

            using (StreamReader sr = new StreamReader(fileStream))
            {
                Data = sr.ReadToEnd();
            }

            Console.WriteLine(Data);
            fileStream.Close();



        }
    }
}