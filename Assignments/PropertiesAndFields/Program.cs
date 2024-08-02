namespace PropertiesAndFields
{
    class Person
    {

        private string name;                //Field

        public string Name { get { return name; } set { name = value; } }     //Properties

        public int Age { get; set; } = 30;      //Auto implemented properties with default value
    }
    internal class PropertiesAndFields
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "Arjun";
            Console.WriteLine(p1.Name);
            p1.Age = 10;
            Console.WriteLine(p1.Age);
        }
    }
}