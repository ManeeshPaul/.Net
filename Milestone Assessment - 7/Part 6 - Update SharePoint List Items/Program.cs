using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Part_6___Update_SharePoint_List_Items
{
    internal class Program
    {
        private static readonly string tenantId = "secret";
        private static readonly string clientId = "secret";
        private static readonly string clientSecret = "secret";

        static async Task Main(string[] args)
        {
            try
            {
                // Retrieve an access token to authenticate with Microsoft Graph
                var accessToken = await GetAccessTokenAsync();

                // Create a GraphServiceClient to interact with Microsoft Graph API
                var client = new GraphServiceClient(new DelegateAuthenticationProvider((requestMessage) =>
                {
                    // Set the Authorization header with the Bearer token
                    requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    return Task.CompletedTask; 
                }));

                string siteUrl = "https://ervikashverma.sharepoint.com/sites/Lists";
                string listName = "Tasks"; 
                string itemId = "1"; 
                string updatedTitle = "Complete the monthly report"; 

                // Call the method to update the SharePoint list item
                await UpdateSharePointListItem(client, siteUrl, listName, itemId, updatedTitle);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the process
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Method to acquire an access token for the Microsoft Graph API
        public static async Task<string> GetAccessTokenAsync()
        {
            // Create a confidential client application with the given credentials
            var app = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
                .WithClientSecret(clientSecret)
                .Build();

            // Acquire a token using client credentials flow
            var result = await app.AcquireTokenForClient(new[] { "https://graph.microsoft.com/.default" }).ExecuteAsync();
            return result.AccessToken; // Return the acquired access token
        }

        // Method to update a specified item in a SharePoint list
        public static async Task UpdateSharePointListItem(GraphServiceClient client, string siteUrl, string listName, string itemId, string updatedTitle)
        {
            try
            {
                // Get the site ID based on the provided SharePoint site URL
                var siteId = await GetSiteIdByUrl(client, siteUrl);

                // Create the updated item object with the new title
                var updatedItem = new ListItem
                {
                    Fields = new FieldValueSet
                    {
                        AdditionalData = new Dictionary<string, object>
                        {
                            { "Title", updatedTitle } // Set the new title
                        }
                    }
                };

                // Update the item in the specified list
                await client.Sites[siteId].Lists[listName].Items[itemId].Request().UpdateAsync(updatedItem);

                // Output success message to the console
                Console.WriteLine($"Item updated successfully: Task ID {itemId}");
            }
            catch (ServiceException ex) when (ex.Error.Code == "itemNotFound")
            {
                // Handle case where the item is not found
                Console.WriteLine($"Error: Item with ID {itemId} not found.");
            }
            catch (Exception ex)
            {
                // Handle other errors that may occur during the update
                Console.WriteLine($"Failed to update item: {ex.Message}");
            }
        }

        // Method to get the site ID using the SharePoint site URL
        public static async Task<string> GetSiteIdByUrl(GraphServiceClient client, string siteUrl)
        {
            // Parse the site URL to extract the hostname and site path
            var uri = new Uri(siteUrl);
            var sitePath = uri.AbsolutePath.Trim('/'); // Get the site path
            var hostname = uri.Host; // Get the hostname

            // Retrieve the site information using the constructed identifier
            var site = await client.Sites[$"{hostname}:{sitePath}"].Request().GetAsync();
            return site.Id; // Return the site ID
        }
    }
}
