namespace String_Program2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputStringValue, finalResult;
            int length;
            char firstLetter, lastLetter;
            Console.WriteLine("Exchange the First and last characters of the string\n");
            Console.Write("Enter the string : ");
            inputStringValue = Console.ReadLine();

            length = inputStringValue.Length;
            if (length == 1)
            {
                Console.WriteLine("Final Result = " + inputStringValue);
            }
            else
            {
                firstLetter = inputStringValue[0];

                lastLetter = inputStringValue[length - 1];

                finalResult = lastLetter + inputStringValue.Substring(1, length - 2) + firstLetter;

                Console.WriteLine("Final Result = " + finalResult);
            }
        }
    }
}