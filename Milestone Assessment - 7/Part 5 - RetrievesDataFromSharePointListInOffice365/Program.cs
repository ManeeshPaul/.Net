
using Microsoft.Identity.Client;
using Microsoft.Graph;

namespace Part_5___RetrievesDataFromSharePointListInOffice365
{
    internal class Program
    {
        private static readonly string tenantId = "secret";
        private static readonly string clientId = "secret";
        private static readonly string clientSecret = "secret";
        private static readonly string siteUrl = "https://ervikashverma.sharepoint.com/sites/Lists";
        private static readonly string listName = "Tasks";

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
                    return Task.CompletedTask; // Complete the task
                }));

                // Define SharePoint site URL and list name to retrieve items from
                string siteUrl = "https://yourtenant.sharepoint.com/sites/yoursite";
                string listName = "Tasks";

                // Call the method to retrieve items from the specified SharePoint list
                await RetrieveSharePointListItems(client, siteUrl, listName);
            }
            catch (Exception ex)
            {
                
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

        // Method to retrieve items from a specified SharePoint list
        public static async Task RetrieveSharePointListItems(GraphServiceClient client, string siteUrl, string listName)
        {
            try
            {
                // Get the site ID based on the provided SharePoint site URL
                var siteId = await GetSiteIdByUrl(client, siteUrl);

                // Retrieve items from the specified list within the site
                var listItems = await client.Sites[siteId].Lists[listName].Items
                    .Request()
                    .GetAsync();

                // Output the retrieved items to the console
                Console.WriteLine($"Items in the '{listName}' list:");
                foreach (var item in listItems)
                {
                    // Retrieve the title of each item, defaulting to "No Title" if not found
                    var title = item.Fields.AdditionalData.ContainsKey("Title") ? item.Fields.AdditionalData["Title"].ToString() : "No Title";
                    Console.WriteLine($"- {title}"); // Print the item title
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Failed to retrieve items: {ex.Message}");
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