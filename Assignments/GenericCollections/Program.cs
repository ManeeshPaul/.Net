namespace GenericCollections
{
    class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public void GetData()
        {
            Console.Write("\nEnter employee Id : ");
            EmpId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter employee Name : ");
            Name = Console.ReadLine();
            Console.Write("Enter Employee salary : ");
            Salary = Convert.ToDouble(Console.ReadLine());
        }
    }
    internal class GenericCollections
    {
        public static void Main(string[] arg)
        {
            /*
            List<int> myList = new List<int>();
            for(int i = 1; i <= 10; i++)
            {
                myList.Add(i);
            }
            foreach(var v in myList)
            {
                Console.WriteLine(v);
            }
            */

            List<Employee> empList = new List<Employee>();

            for (int i = 1; i <= 2; i++)
            {
                Employee emp = new Employee();
                emp.GetData();
                empList.Add(emp);
            }
            foreach (Employee e in empList)
            {
                Console.WriteLine("\nEmployee Id : " + e.EmpId);
                Console.WriteLine("Employee Name : " + e.Name);
                Console.WriteLine("Employee Salary : " + e.Salary);
            }

        }
    }
}