namespace Electricity_Bill
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int unit;
            double TotalBill;

            Console.WriteLine("Enter the total unit");
            unit = Convert.ToInt32(Console.ReadLine());

            if (unit <= 50)
            {
                TotalBill = unit * 0.5;
            }
            else if (unit <= 150)
            {
                TotalBill = 50 * 0.5 + (unit - 50) * 0.75;
            }
            else if (unit <= 250)
            {
                TotalBill = 50 * 0.5 + 100 * 0.75 + (unit - 150) * 1.2;
            }
            else
            {
                TotalBill = 50 * 0.5 + 100 * 0.75 + 100 * 1.2 + (unit - 250) * 1.5;
            }

            TotalBill = TotalBill + TotalBill * 0.2;


            Console.WriteLine("Total Bill = " + TotalBill.ToString());
        }
    }
}