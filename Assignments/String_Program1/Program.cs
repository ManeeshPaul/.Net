namespace String_Program1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputStringValue;
            char firstLetter;
            Console.WriteLine("Add the First character of the string at the begining and end \n");
            Console.Write("Enter the string : ");
            inputStringValue = Console.ReadLine();

            firstLetter = inputStringValue[0];

            inputStringValue = firstLetter + inputStringValue + firstLetter;

            Console.WriteLine("Final Result = " + inputStringValue);
        }
    }
}