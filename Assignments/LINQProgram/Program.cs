namespace LINQProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] languages = { "java", "php", "python", "c++", "c", "c#" };
            var result = from lang in languages where lang.Contains('c') select lang;

            foreach (var lan in result)
            {
                Console.WriteLine(lan);
            }
        }
    }
}