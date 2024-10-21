using System.Diagnostics;

namespace Part4_InvokePythonScript
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Defining the Python script path and the arguments
                string pythonScriptPath = "C:\\Users\\Administrator\\Desktop\\CSharp\\Tasks\\Milestone Assessment - 6\\sum_script.py"; 
                string arg1 = "5"; // First number
                string arg2 = "10"; // Second number

                // Creating a new process to invoke the Python script
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "C:\\Users\\Administrator\\AppData\\Local\\Programs\\Python\\Python313\\python.exe", 
                    Arguments = $"\"{pythonScriptPath}\" {arg1} {arg2}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

           
                using (Process process = Process.Start(startInfo))
                {
                    // Capture the output
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    // Display the results
                    if (!string.IsNullOrEmpty(error))               
                    {
                        Console.WriteLine($"Error: {error}");
                    }
                    else
                    {
                        Console.WriteLine($"The sum is: {output.Trim()}"); //Displaying the output
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}