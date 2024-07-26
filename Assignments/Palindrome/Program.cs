namespace Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputValue1, inputValue;
            int inputValueLength, flag = 0;

            Console.Write("Palindrome\n\n");
            Console.Write("Enter the string : ");
            inputValue1 = Console.ReadLine();
            inputValue = inputValue1.ToLower();

            inputValueLength = inputValue.Length;

            int x = 0, y = inputValueLength - 1;
            for (int i = 0; i < inputValueLength / 2; i++)
            {
                if (inputValue[x] == inputValue[y])
                {
                    x++;
                    y--;
                }
                else
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("\n" + inputValue1 + " is a palindrome");
            }
            else
            {
                Console.WriteLine(inputValue1 + " is not a palindrome");
            }
        }
    }
}