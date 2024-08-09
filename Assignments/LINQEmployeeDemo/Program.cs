namespace LINQEmployeeDemo
{
    internal class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public double Salary { get; set; }

        public int DeptId { get; set; }

    }

    class Department
    {
        public int DeptId { get; set; }
        public string DepartmentName { get; set; }
    }

    class EmployeeDemoClass
    {
        public static void Main(string[] arg)
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee { Id = "101", Name = "Arun", Salary = 10000, DeptId = 2 });
            empList.Add(new Employee { Id = "102", Name = "Hari", Salary = 9000, DeptId = 3 });
            empList.Add(new Employee { Id = "103", Name = "Jinu", Salary = 11000, DeptId = 1 });

            List<Department> deptList = new List<Department>();
            deptList.Add(new Department { DeptId = 1, DepartmentName = "IT" });
            deptList.Add(new Department { DeptId = 2, DepartmentName = "Admin" });
            deptList.Add(new Department { DeptId = 3, DepartmentName = "Sales" });
            deptList.Add(new Department { DeptId = 4, DepartmentName = "Security" });

            //var result=from emp in empList where emp.Salary>10000 select emp;   

            /*foreach(var item in result)
            {
                Console.WriteLine("Id :"+item.Id+", Name : "+item.Name); 
            }
            */
            var result = (from employee in empList
                          join dept in deptList
                         on employee.DeptId equals dept.DeptId
                          select new
                          {
                              ID = employee.Id,
                              Name = employee.Name,
                              DepartmentName = dept.DepartmentName
                          }).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.ID + " | " + item.Name + " | " + item.DepartmentName);
            }
        }
    }
}