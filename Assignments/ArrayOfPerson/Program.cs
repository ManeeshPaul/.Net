namespace ArrayOfPerson
{
    class Person
    {
        public string name;
        public Person(string name)
        {
            this.name = name;
        }

        ~Person()
        {
            name = string.Empty;
        }
        public override string ToString()
        {
            return "Hello my name is " + name;
        }


    }
    internal class Program
    {

        static void Main(string[] args)
        {
            string nameInput;
            Person[] p = new Person[3];
            Console.WriteLine("Enter 3 names");
            for (int i = 0; i < 3; i++)
            {
                nameInput = Console.ReadLine();
                p[i] = new Person(nameInput);
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(p[i].ToString());
            }
        }
    }
}