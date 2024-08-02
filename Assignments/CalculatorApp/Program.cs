using CalculatorLibrary;

namespace CalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CalculatorLibrary.Calculator calculator = new CalculatorLibrary.Calculator(); 
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Sum(3, 7));        }
    }
}