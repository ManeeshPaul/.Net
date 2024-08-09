namespace LINQLambdaQueryOperators
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }
    }
    internal class LINQLambdaQueryOperators
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee { Id = "101", Name = "Arun", Gender = "Male", Salary = 10000 });
            empList.Add(new Employee { Id = "102", Name = "Jinu", Gender = "Male", Salary = 20000 });
            empList.Add(new Employee { Id = "103", Name = "Aishwarya", Gender = "Female", Salary = 15000 });
            empList.Add(new Employee { Id = "104", Name = "Ankitha", Gender = "Female", Salary = 25000 });
            empList.Add(new Employee { Id = "105", Name = "Megha", Gender = "Female", Salary = 27000 });
            empList.Add(new Employee { Id = "106", Name = "Hari", Gender = "Male", Salary = 40000 });

            //Group by
            /*
            var result=empList.GroupBy(x=>x.Gender).ToList();

            foreach(var item in result)
            {
                Console.WriteLine(item.Key+"\n");
                foreach (Employee emp in item)
                {
                    Console.WriteLine(emp.Name);
                }
                Console.WriteLine("\n");
            }
            */


            //OrderBy
            /*
            var res=empList.OrderBy(x => x.Id).ToList();
            foreach (var item in res)
            {
                Console.WriteLine(item.Id+" | "+item.Name);
            }

            */

            //Console.WriteLine("============DESC=================");

            /*
            var res = empList.OrderByDescending(x=>x.Id).ToList();
            foreach (var item in res)
            {
                Console.WriteLine(item.Id + " | " + item.Name);
            }
            */

            // ToLookUp
            /*
            var res = empList.ToLookup(x => x.Gender);

            foreach (var item in res)
            {
                Console.WriteLine(item.Key + "\n");
                foreach (Employee e in item)
                {
                    Console.WriteLine(e.Name);
                }
                Console.WriteLine("=============================");
            }
            */


            //var res = empList.Average(x => x.Salary);         //Average
            // Console.WriteLine(res);

            //var res = empList.Sum(x => x.Salary);               //Sum
            //Console.WriteLine(res);

            //var res = empList.Max(x => x.Salary);               //Max
            //Console.WriteLine(res);

            //var res = empList.Count(x => x.Salary>=25000);               //Count
            //Console.WriteLine(res);

            //Distinct
            /*
            var distinctIds = empList.Select(e => e.Id).Distinct().ToList();
            Console.WriteLine("Distinct IDs:");
            foreach (var id in distinctIds)
            {
                Console.WriteLine(id);
            }
            */


            //---------UNION--------   //Union combines two collections and removes duplicates. 

            /*
            List<Employee> otherList = new List<Employee>
            {
                new Employee { Id = "107", Name = "Sita", Gender = "Female", Salary = 30000 },
                new Employee { Id = "108", Name = "Ravi", Gender = "Male", Salary = 35000 }
            };

            var unionList = empList.Union(otherList).ToList();
            Console.WriteLine("Union of empList and otherList:");
            foreach (var emp in unionList)
            {
                Console.WriteLine($"{emp.Id} | {emp.Name} | {emp.Salary}");
            }
            */


            //-----------Concat------------  // Unlike Union, it does not remove duplicates:

            /*
            List<Employee> otherList = new List<Employee>
            {
                new Employee { Id = "107", Name = "Sita", Gender = "Female", Salary = 30000 },
                new Employee { Id = "108", Name = "Ravi", Gender = "Male", Salary = 35000 }
            };
            var concatList = empList.Concat(otherList).ToList();
            Console.WriteLine("Concat of empList and otherList:");
            foreach (var emp in concatList)
            {
                Console.WriteLine($"{emp.Id} | {emp.Name} | {emp.Salary}");
            }
            */


            //---------Skipp------------//Skip skips a specified number of elements and returns the remaining elements. 

            /*
            var skippedList = empList.Skip(2).ToList();
            Console.WriteLine("Employees after skipping the first 2:");
            foreach (var emp in skippedList)
            {
                Console.WriteLine($"{emp.Id} | {emp.Name} | {emp.Salary}");
            }
            */

            //-----------Take-------------//Take takes a specified number of elements from the beginning of a collection.

            var takenList = empList.Take(3).ToList();
            Console.WriteLine("First 3 employees:");
            foreach (var emp in takenList)
            {
                Console.WriteLine($"{emp.Id} | {emp.Name} | {emp.Salary}");
            }



        }
    }
}