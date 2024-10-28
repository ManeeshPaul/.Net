using System; 
using log4net; 

// Configure log4net
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace Part_8___Logging_Using_Log4net
{
    internal class Program
    {
        // Create a logger for this class
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            try
            {
                logger.Info("Application started");

                // Simulate checking for disk space
                CheckDiskSpace();

                // Simulate an error
                ProcessData();

                Console.WriteLine("log Completed");
            }
            catch (Exception ex)
            {
                
                logger.Error("An error occurred during processing", ex);
            }
            finally
            {
                
                logger.Info("Application ended");
            }
        }

        static void CheckDiskSpace()
        {
            logger.Warn("Low disk space"); // Log a warning
        }

        static void ProcessData()
        {
            throw new InvalidOperationException("Data processing failed"); // Simulate an error
        }
    }
}
