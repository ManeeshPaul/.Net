using Azure.Identity; //This library provides a set of authentication classes for Azure SDKs, enabling developers to
                      //easily obtain Azure Active Directory tokens using various authentication methods, such as
                      //client secrets, managed identities, or interactive login.
using Microsoft.Graph; // This library is a client SDK for accessing the Microsoft Graph API, allowing developers to
                       // interact with various Microsoft 365 services and resources, such as user data, OneDrive
                       // files, and Teams, using a unified API interface.



namespace Part_1___List_SharePoint_Documents
{
    internal class Program
    {

        private static readonly string tenantId = "secret";
        private static readonly string clientId = "secret";
        private static readonly string clientSecret = "secret";
        private static readonly string userEmail = "VikashVerma@ervikashverma.onmicrosoft.com";
        
       

        static async Task Main(string[] args)
        {
            try
            {
                // Create a credential object using the client secret
                var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
                // Initialize GraphServiceClient with the credential
                var client = new GraphServiceClient(credential);

                // List files in the user's OneDrive
                await ListFilesInDrive(client, userEmail);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred: {ex.Message}");
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