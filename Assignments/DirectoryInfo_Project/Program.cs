namespace DirectoryInfo_Project
{
    internal class DirectoryInfoClass
    {
        public static void Main(string[] arg)
        {
            string sourceFolderPath = @"C:\Users\Administrator\Desktop\CSharp\File_Handling\SourceFolder";
            string destinationFolderPath = @"C:\Users\Administrator\Desktop\CSharp\File_Handling\DestinationFolder";
            string fileDemoPath = @"C:\Users\Administrator\Desktop\CSharp\File_Handling\FileDemo";
            DirectoryInfo d1 = new DirectoryInfo(sourceFolderPath);
            //d1.create;
            //d1.CreateSubdirectory("Sample");


            DirectoryInfo d2 = new DirectoryInfo(destinationFolderPath);

            if (d2.Exists)
            {
                Console.WriteLine("The destination directory already exists.");
            }
            else
            {
                // Move the source directory to the destination path
                d1.MoveTo(destinationFolderPath);      ////Here destination folder should not be created, other wise it will throw exception
            }

            DirectoryInfo d3 = new DirectoryInfo(fileDemoPath);
            d3.Delete();

        }


    }
}