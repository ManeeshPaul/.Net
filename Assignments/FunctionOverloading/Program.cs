namespace FunctionOverloading
{
    class OverloadingDemo
    {
        public void Sum()
        {
            Console.WriteLine(2 + 3);
        }
        public void Sum(string a, string b)
        {
            Console.WriteLine(a + b);
        }
        public void Sum(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public void Sum(int a, int b, int c)
        {
            Console.WriteLine(a + b + c);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            OverloadingDemo overloading = new OverloadingDemo();
            overloading.Sum();
            overloading.Sum("Hi ", "Welcome");
            overloading.Sum(4, 5);
            overloading.Sum("4", "5");
            overloading.Sum(1, 6, 3);

        }
    }
}