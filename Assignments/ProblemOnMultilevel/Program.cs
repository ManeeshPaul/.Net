namespace ProblemOnMultilevel
{
    class Person
    {
        public int age;
        public void Greet()
        {
            Console.WriteLine("Hello ");
        }
        public void SetAge(int age)
        {
            this.age = age;
        }
    }
    class Student : Person
    {
        public void Study()
        {
            Console.WriteLine("I'm Studying on the screen");
        }
    }
    class Teacher : Person
    {
        public void Explain()
        {
            Console.WriteLine("I'm explaining on the screen");
        }
        public void ShowAge(int x)
        {
            Console.WriteLine("My Age is " + x + "old in the screen");
        }
    }
    internal class StudentProfessorTest
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Greet();

            Student s = new Student();
            s.SetAge(15);
            s.Greet();
            Console.WriteLine("Age : " + s.age);

            Teacher t = new Teacher();
            t.SetAge(40);
            t.Greet();
            t.Explain();
        }
    }
}