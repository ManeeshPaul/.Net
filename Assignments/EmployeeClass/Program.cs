namespace EmployeeClass
{
    class Employee
    {
        public int EmployeeId;
        public string EmployeeName;
        public string Salary;
        public string Gender;

        public void GetData()
        {
            Console.Write("Enter EmployeeId : ");
            EmployeeId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name : ");
            EmployeeName = Console.ReadLine();
            Console.Write("Enter Employee salary : ");
            Salary = Console.ReadLine();
            Console.Write("Enter Employee gender : ");
            Gender = Console.ReadLine();
        }
        public void PrintData(Employee employee)
        {
            Console.WriteLine("\nEmployee Id : " + employee.EmployeeId);
            Console.WriteLine("Employee Name : " + employee.EmployeeName);
            Console.WriteLine("Employee Salary : " + employee.Salary);
            Console.WriteLine("Employee Gender : " + employee.Gender);
        }

    }
    internal class ClassesAndObejects
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            emp1.GetData();
            emp1.PrintData(emp1);
        }
    }
}