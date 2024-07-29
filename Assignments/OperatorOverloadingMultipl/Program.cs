namespace OperatorOverloadingMultipl
{
    class Sample2
    {
        int number1, number2;
        public Sample2(int a, int b)
        {
            number1 = a;
            number2 = b;
        }
        public void Print()
        {
            Console.WriteLine("Number1 : " + number1 + "\nNumber2 : " + number2);
        }
        public static Sample2 operator *(Sample2 s1, Sample2 s2)
        {
            Sample2 s3 = new Sample2(0, 0);
            s3.number1 = s1.number1 * s2.number1;
            s3.number2 = s1.number2 * s2.number2;
            return s3;
        }
    }
    internal class OperatorOverloadingMulti
    {
        static void Main(string[] args)
        {
            Sample2 s1 = new Sample2(2, 4);
            Sample2 s2 = new Sample2(5, 3);
            Sample2 s3 = s1 * s2;
            s3.Print();

        }
    }
}