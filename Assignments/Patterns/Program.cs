namespace Patterns
{
    internal class Patterns
    {
        //Pattern 1
        public static void Pattern1()
        {
            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine("\n");

            }
        }

        //Pattern 2
        public static void Pattern2()
        {
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    if (i == 0 || j == 0 || i == 8 || j == 8 || i == j || j == 8 - i)
                    {
                        Console.Write(" * ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                }
                Console.WriteLine("\n");

            }
        }

        //Pattern 3
        public static void Pattern3()
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    if (j >= i || i == 9 - j || 9 - j <= i)
                    {
                        Console.Write(" * ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                }
                Console.WriteLine("\n");

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Pattern 1");
            Pattern1();
            Console.WriteLine("Pattern 2");
            Pattern2();
            Console.WriteLine("Pattern 3");
            Pattern3();
        }
    }
}