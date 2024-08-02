namespace MultipleInterfaceIssue
{
    interface IWholeSeller
    {
        void Discount();
    }
    interface IRetailer
    {
        void Discount();
    }
    class Buyer : IWholeSeller, IRetailer
    {
        void IWholeSeller.Discount()
        {
            Console.WriteLine("I am called from Demo IWholeSeller");
        }
        void IRetailer.Discount()
        {
            Console.WriteLine("I am called from Demo IRetailer");
        }
        void Print()
        {

        }

    }
    internal class Program
    {

        static void Main(string[] args)
        {
            IWholeSeller d1 = new Buyer();
            d1.Discount();

            IRetailer d2 = new Buyer();
            d2.Discount();

        }
    }
}