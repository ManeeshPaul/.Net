namespace CopyConstructor
{
    class Vehicle
    {
        public string name;
        public string color;

        //Copy constructor
        public Vehicle(Vehicle vehicle)
        {
            name = vehicle.name;
            color = vehicle.color;
        }
        public Vehicle(String name, string color)
        {
            this.name = name;
            this.color = color;
        }
        public void PrintData()
        {
            Console.WriteLine("\nModel Name : " + name + "\nColor : " + color);
        }

        //Destructor
        ~Vehicle()
        {

        }


    }
    internal class CopyConstructor
    {
        static void Main(string[] args)
        {
            Vehicle v1 = new Vehicle("Bike", "Black");
            Vehicle v2 = new Vehicle(v1);
            v2.PrintData();
        }
    }
}