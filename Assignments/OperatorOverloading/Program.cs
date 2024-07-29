namespace OperatorOverloadingPlus
{
    class Sample
    {
        int number1, number2;
        public Sample(int a, int b)
        {
            number1 = a;
            number2 = b;
        }
        public void Print()
        {
            Console.WriteLine("Number1 : " + number1 + "\nNumber2 : " + number2);
        }
        public static Sample operator +(Sample s1, Sample s2)
        {
            Sample s3 = new Sample(0, 0);
            s3.number1 = s1.number1 + s2.number1;
            s3.number2 = s1.number2 + s2.number2;
            return s3;
        }
    }
    internal class OperatorOverloadingPlus
    {
        static void Main(string[] args)
        {
            Sample s1 = new Sample(1, 2);
            Sample s2 = new Sample(2, 4);
            Sample s3 = s1 + s2;
            s3.Print();
        }

    }
}