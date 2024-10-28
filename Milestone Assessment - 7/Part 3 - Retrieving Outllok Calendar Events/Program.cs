using Microsoft.Identity.Client;
using Microsoft.Graph;
using Azure.Identity;
using System;
using System.Threading.Tasks;

namespace Part_3___Retrieving_Outllok_Calendar_Events
{
    internal class Program
    {
        private static readonly string tenantId = "secret";
        private static readonly string clientId = "secret";
        private static readonly string clientSecret = "secret";
        private static readonly string[] scopes = new[] { "https://graph.microsoft.com/.default" };
        private static readonly string userEmail = "VikashVerma@ervikashverma.onmicrosoft.com"; 

        static async Task Main(string[] args)
        {
            try
            {
                var accessToken = await GetAccessTokenAsync();
                var client = new GraphServiceClient(new DelegateAuthenticationProvider((requestMessage) =>
                {
                    requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    return Task.CompletedTask;
                }));

                // Call the method to read and display calendar events
                await ReadCalendarEvents(client, userEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static async Task<string> GetAccessTokenAsync()
        {
            var app = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
                .WithClientSecret(clientSecret)
                .Build();

            var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
            return result.AccessToken;
        }

        public static async Task ReadCalendarEvents(GraphServiceClient client, string userEmail)
        {
            // Define the date range for retrieving events 
            var startDateTime = DateTime.UtcNow;
            var endDateTime = startDateTime.AddDays(30);

            // Get the user's calendar events within the specified date range
            var events = await client.Users[userEmail].Events
                .Request()
                .Filter($"start/dateTime ge '{startDateTime:yyyy-MM-ddTHH:mm:ssZ}' and end/dateTime le '{endDateTime:yyyy-MM-ddTHH:mm:ssZ}'")
                .GetAsync();

            // Check if there are any events retrieved
            if (events.Count == 0)
            {
                Console.WriteLine("No upcoming events found.");
            }
            else
            {
                Console.WriteLine("Upcoming Events:");
                foreach (var calendarEvent in events)
                {
                    // Print the event details 
                    Console.WriteLine($"- {calendarEvent.Subject}: {calendarEvent.Start.DateTime}");
                }
            }
        }
    }
}
