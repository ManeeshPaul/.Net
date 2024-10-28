using Microsoft.Identity.Client; 
using Microsoft.Graph;
using System.IO;


namespace Part_4___Send_Email
{
    internal class Program
    {
        private static readonly string tenantId = "secret";
        private static readonly string clientId = "secret";
        private static readonly string clientSecret = "secret";
        private static readonly string[] scopes = new[] { "https://graph.microsoft.com/.default" };

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

                // Example usage of the SendEmailWithAttachment function
                string recipient = "maneeshpaulvtl@gmail.com";
                string subject = "Monthly Report";
                string body = "Please find the attached report.";
                string attachmentPath = "Report.pdf";

                await SendEmailWithAttachment(client, recipient, subject, body, attachmentPath);
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
            return result.AccessToken; // Return the access token
        }

        public static async Task SendEmailWithAttachment(GraphServiceClient client, string recipient, string subject, string body, string attachmentPath)
        {
            try
            {
                // Create the email message
                var message = new Message
                {
                    Subject = subject,
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Text,
                        Content = body
                    },
                    ToRecipients = new List<Recipient>
                    {
                        new Recipient
                        {
                            EmailAddress = new EmailAddress
                            {
                                Address = recipient
                            }
                        }
                    },
                    Attachments = new MessageAttachmentsCollectionPage() // Initialize the attachment collection
                };

                // Check if the attachment file exists
                if (System.IO.File.Exists(attachmentPath))
                {
                    // Read the file and create the attachment
                    var attachment = new FileAttachment
                    {
                        Name = Path.GetFileName(attachmentPath),
                        ContentType = "application/pdf", // Set appropriate content type
                        ContentBytes = await System.IO.File.ReadAllBytesAsync(attachmentPath) // Read file as byte array
                    };
                    message.Attachments.Add(attachment); // Add the attachment to the message
                }
                else
                {
                    Console.WriteLine("Attachment file does not exist.");
                    return; // Exit if the file does not exist
                }

                // Send the email
                await client.Users["VikashVerma@ervikashverma.onmicrosoft.com"].SendMail(message, true).Request().PostAsync();

                Console.WriteLine($"Email sent successfully to {recipient}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }
    }
}