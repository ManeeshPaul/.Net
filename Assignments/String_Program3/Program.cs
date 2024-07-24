namespace String_Program3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputStringValue, finalResult, firstThreeLetters;
            int length;

            Console.WriteLine("Add the First three letters at the front and back of the string\n");
            Console.Write("Enter the string : ");
            inputStringValue = Console.ReadLine();

            length = inputStringValue.Length;
            if (length <= 3)
            {
                finalResult = inputStringValue + inputStringValue + inputStringValue;
                Console.WriteLine("Final Result = " + finalResult);
            }
            else
            {
                firstThreeLetters = inputStringValue.Substring(0, 3);

                finalResult = firstThreeLetters + inputStringValue + firstThreeLetters;

                Console.WriteLine("Final Result = " + finalResult);
            }
        }
    }
}