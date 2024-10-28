using Azure.Identity;
using Microsoft.Graph;

//The SharePoint API enables file uploads by first authenticating through Azure Active Directory to
//obtain an access token. For larger files, an upload session is created to facilitate chunked uploads,
//allowing the file to be sent in manageable parts. Once all chunks are uploaded, the session is
//finalized, and the API returns details about the uploaded file.

namespace Part_2___Upload_Documents_to_SharePoint
{
    internal class Program
    {

        private static readonly string tenantId = "secret";
        private static readonly string clientId = "secret";
        private static readonly string clientSecret = "secret";
        private static readonly string userEmail = "VikashVerma@ervikashverma.onmicrosoft.com";
        private static readonly string filePath = "LatestTestingFile.txt";


        static async Task Main(string[] args)
        {
            try
            {
                // Create a credential object using the client secret
                var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
                // Initialize GraphServiceClient with the credential
                var client = new GraphServiceClient(credential);
                var uplaodedFile = await UploadFileToDrive(client, filePath);

                // List files in the user's OneDrive
                await ListFilesInDrive(client, userEmail);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        private static async Task<DriveItem> UploadFileToDrive(GraphServiceClient client, string filePath)
        {
            // Extract the file name from the provided file path
            var fileName = Path.GetFileName(filePath);

            try
            {
                // Open the file stream for reading the file
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Create an upload session for the specified file path in OneDrive
                    var uploadSession = await client.Users[userEmail].Drive.Root.ItemWithPath(fileName)
                        .CreateUploadSession().Request().PostAsync();

                    // Define the maximum chunk size for the upload (320 KB in this case)
                    var maxChunkSize = 320 * 1024; // 320 KB

                    // Create a chunked upload provider to handle the file upload in chunks
                    var chunkUploadProvider = new ChunkedUploadProvider(uploadSession, client, fileStream, maxChunkSize);

                    // Perform the upload and retrieve the uploaded item details
                    var uploadedItem = await chunkUploadProvider.UploadAsync();

                    // Inform the user that the upload was successful
                    Console.WriteLine($"File uploaded successfully : {fileName}");
                    return uploadedItem; // Return the uploaded item
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the upload process
                Console.WriteLine($"Error uploading file: {ex.Message}");
                throw; // Re-throw the exception if needed for further handling
            }
        }

        // Method to list files in the specified user's OneDrive
        private static async Task ListFilesInDrive(GraphServiceClient client, string userEmail)
        {
            try
            {
                // Retrieve the list of files in the user's OneDrive root directory
                var driveItems = await client.Users[userEmail].Drive.Root.Children.Request().GetAsync();

                Console.WriteLine("\nList of Files in OneDrive\n*************************\n");
                                     
                // Iterate through and print the name and ID of each file
                foreach (var driveItem in driveItems)
                {
                    Console.WriteLine($"- {driveItem.Name} (Id: {driveItem.Id})");
                }
            }
            catch (ServiceException ex)
            {
                // Handle errors specific to the Graph API service
                Console.WriteLine($"Error retrieving files: {ex.Message}");
            }
        }
    }
}