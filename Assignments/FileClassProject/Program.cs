namespace FileClassProject
{
    internal class FileDemoClass
    {
        public static void Main(string[] arg)
        {

            string sourceFilePath = @"C:\Users\Administrator\Desktop\CSharp\File_Handling\Sample.txt";
            string destinationFilePath = @"C:\Users\Administrator\Desktop\CSharp\File_Handling\DestinationFile.txt";

            if (File.Exists(destinationFilePath))
            {
                File.Copy(sourceFilePath, destinationFilePath, true);
                //File.Delete(destinationFilePath);
                //File.Create(destinationFilePath);   
            }
            else
            {
                Console.WriteLine("Destination file does not exists");
            }
        }
    }
}