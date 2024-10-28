using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;


namespace Part_7___Logging
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Set up the logging service
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConsole(); // Log to console
                    builder.AddFile("app.log"); // Log to a file
                })
                .BuildServiceProvider();

            // Create a logger instance
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            // Log messages with timestamps
            LogApplicationEvents(logger);
        }

        private static void LogApplicationEvents(ILogger logger)
        {
            try
            {
                logger.LogInformation("Application started");

                
                logger.LogInformation("Performing operation...");

                
                logger.LogInformation("Application ended");
            }
            catch (Exception ex)
            {
                logger.LogError($"An error occurred: {ex.Message}");
            }
        }
    }

    // Extension method to add file logging
    public static class FileLoggerExtensions
    {
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string filePath)
        {
            builder.AddProvider(new FileLoggerProvider(filePath));
            return builder;
        }
    }

    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _filePath;

        public FileLoggerProvider(string filePath)
        {
            _filePath = filePath;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_filePath);
        }

        public void Dispose()
        {
           
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            var logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

            // Append the log message to the file
            try
            {
                File.AppendAllText(_filePath, logMessage + Environment.NewLine);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"Logging failed: {ioEx.Message}");
            }
        }
    }
}