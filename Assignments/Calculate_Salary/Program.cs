namespace Calculate_Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int basicSalary;
            double grossSalary, HRA, DA;
            Console.WriteLine("Salary calculation");
            Console.WriteLine("Enter your Basic salary");
            basicSalary = Convert.ToInt32(Console.ReadLine());

            if (basicSalary <= 10000)
            {
                HRA = basicSalary * 0.2;
                DA = basicSalary * 0.8;
            }
            else if (basicSalary <= 20000)
            {
                HRA = basicSalary * 0.25;
                DA = basicSalary * 0.9;
            }
            else
            {
                HRA = basicSalary * 0.3;
                DA = basicSalary * 0.95;
            }
            grossSalary = basicSalary + HRA + DA;

            Console.WriteLine("Gross Salary = " + grossSalary);
        }
    }
}